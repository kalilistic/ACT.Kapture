#!/usr/bin/env python
import pandas as pd
import warnings

# Suppress Warnings
warnings.simplefilter(action="ignore", category=FutureWarning)

# General Variables
sep = "\x01"
src_dir = "../SaintCoinachExtracts/"
dest_dir = "../src/Aetherbridge/Properties/"
property_ext = ".csv"
primary_lang = "en"
addl_langs = ["fr", "de", "ja"]

# Extract File Names
class_job_file_name = "ClassJob"
world_file_name = "World"
item_file_name = "Item"
content_finder_condition_file_name = "ContentFinderCondition"
territory_type_file_name = "TerritoryType"
place_name_file_name = "PlaceName"
map_file_name = "Map"
language_file_name = "Language"
item_action_file_name = "ItemAction"

# Destination File Paths
class_job_dest = dest_dir + class_job_file_name + property_ext
world_dest = dest_dir + world_file_name + property_ext
item_dest = dest_dir + item_file_name + property_ext
content_finder_condition_dest = (
    dest_dir + content_finder_condition_file_name + property_ext
)
territory_type_dest = dest_dir + territory_type_file_name + property_ext
place_name_dest = dest_dir + place_name_file_name + property_ext
map_dest = dest_dir + map_file_name + property_ext
language_dest = dest_dir + language_file_name + property_ext
item_action_dest = dest_dir + item_action_file_name + property_ext

# Extract Columns
class_job_cols = ["Key", "ClassJobCategory", "Role", "Name", "Abbreviation"]
world_cols = ["Key", "Name"]
item_cols = ["Key", "ItemSearchCategory", "IsUntradable", "Price{Low}", "ItemAction", "Singular", "Plural", "Name"]
content_finder_condition_cols = ["Key", "TerritoryType", "HighEndDuty", "Name"]
territory_type_cols = [
    "Key",
    "PlaceName{Region}",
    "PlaceName{Zone}",
    "PlaceName",
    "Map",
]
place_name_cols = ["Key", "Name"]
map_cols = ["Key", "PlaceName{Sub}", "TerritoryType"]
item_action_cols = ["Key", "Type"]

# Common Functions
def remove_dummy_headers(file_src, file_dest):
    df = pd.read_csv(file_src, low_memory=False)
    df = df.drop([1, 1])
    df.to_csv(file_dest, sep=sep, header=False, index=False)


def rename_key_col(df):
    return df.rename(columns={"#": "Key"})


def read_csv(file_name):
    return pd.read_csv(file_name, sep=sep)


def remove_unused_cols(df, cols):
    return df[cols].replace(cols)


def write_transformed_csv(df, file_name):
    df.to_csv(file_name, sep=sep, header=False, index=False)


def merge_df_exclude_dupes(df1, df2):
    df = df1.merge(df2, on="Key", how="outer", suffixes=("", "_dupe"))
    df = df.drop(list(df.filter(regex="_dupe$")), axis=1)
    return df


def remove_placeholders(df):
    df = df.replace({"<Emphasis>": ""}, regex=True)
    df = df.replace({"</Emphasis>": ""}, regex=True)
    df = df.replace({"<Emphasis/>": ""}, regex=True)
    df = df.replace({"<Indent>": ""}, regex=True)
    df = df.replace({"</Indent>": ""}, regex=True)
    df = df.replace({"<Indent/>": ""}, regex=True)
    df = df.replace({"<SoftHyphen>": ""}, regex=True)
    df = df.replace({"</SoftHyphen>": ""}, regex=True)
    df = df.replace({"<SoftHyphen/>": ""}, regex=True)
    return df


def transform_class_job():
    df = create_class_job_df(primary_lang)
    for lang in addl_langs:
        addl_df = create_class_job_df(lang)
        df = merge_df_exclude_dupes(df, addl_df)
    write_transformed_csv(df, class_job_dest)


def create_class_job_df(lang):
    class_job_src = src_dir + lang + "/" + class_job_file_name + property_ext
    remove_dummy_headers(class_job_src, class_job_dest)
    df = read_csv(class_job_dest)
    df = rename_key_col(df)
    df = remove_unused_cols(df, class_job_cols)
    df = df.rename(columns={"Name": "Name{" + lang + "}"})
    df = df.rename(columns={"Abbreviation": "Abbreviation{" + lang + "}"})
    return df


def transform_world():
    world_src = src_dir + primary_lang + "/" + world_file_name + property_ext
    remove_dummy_headers(world_src, world_dest)
    df = read_csv(world_dest)
    df = rename_key_col(df)
    df = df[df["IsPublic"]]
    df = remove_unused_cols(df, world_cols)
    write_transformed_csv(df, world_dest)


def transform_item():
    df = create_item_df(primary_lang)
    for lang in addl_langs:
        addl_df = create_item_df(lang)
        df = merge_df_exclude_dupes(df, addl_df)
    item_custom_data = pd.read_csv("../custom-data/Item.csv")
    df = merge_df_exclude_dupes(df, item_custom_data)
    df = df.fillna({"IsCommon": False, "IsRetired": False, "ItemSearchCategory": 0, "Price{Low}": 0, "ItemAction": 0})
    df = df.sort_values(by=["IsCommon", "Key"], ascending=[False, False])
    df["ItemSearchCategory"] = df["ItemSearchCategory"].astype(int)
    df["Price{Low}"] = df["Price{Low}"].astype(int)
    df["ItemAction"] = df["ItemAction"].astype(int)
    write_transformed_csv(df, item_dest)


def create_item_df(lang):
    item_src = src_dir + lang + "/" + item_file_name + property_ext
    remove_dummy_headers(item_src, item_dest)
    df = read_csv(item_dest)
    df = rename_key_col(df)
    df = df[df["Singular"] != ""]
    df = df[df["Plural"] != ""]
    df = df[df["Name"] != ""]
    df = df.drop_duplicates(["Singular", "Plural", "Name"])
    df = remove_placeholders(df)
    df = df.applymap(lambda x: x.strip() if isinstance(x, str) else x)
    df = df.drop([0, 0])
    df = remove_unused_cols(df, item_cols)
    df["SingularSearchTerm"] = ""
    df["PluralSearchTerm"] = ""
    df["SingularREP"] = ""
    df["PluralREP"] = ""
    if lang == "en":
        df["SingularSearchTerm"] = df["Singular"]
        df["PluralSearchTerm"] = df["Plural"]
        df.loc[
            (df["SingularSearchTerm"].str.startswith("the ", na=False)),
            "SingularSearchTerm",
        ] = df["SingularSearchTerm"].replace({"^the ": ""}, regex=True)
        df.loc[
            (df["SingularSearchTerm"].str.startswith("an ", na=False)),
            "SingularSearchTerm",
        ] = df["SingularSearchTerm"].replace({"^an ": ""}, regex=True)
        df.loc[
            (df["SingularSearchTerm"].str.startswith("a ", na=False)),
            "SingularSearchTerm",
        ] = df["SingularSearchTerm"].replace({"^a ": ""}, regex=True)
        df.loc[
            (df["PluralSearchTerm"].str.startswith("the ", na=False)),
            "PluralSearchTerm",
        ] = df["PluralSearchTerm"].replace({"^the ": ""}, regex=True)
        df.loc[
            (df["PluralSearchTerm"].str.startswith("an ", na=False)), "PluralSearchTerm"
        ] = df["PluralSearchTerm"].replace({"^an ": "?"}, regex=True)
        df.loc[
            (df["PluralSearchTerm"].str.startswith("a ", na=False)), "PluralSearchTerm"
        ] = df["PluralSearchTerm"].replace({"^a ": ""}, regex=True)
    elif lang == "fr":
        df["SingularSearchTerm"] = df["Singular"]
        df["PluralSearchTerm"] = df["Plural"]
    elif lang == "de":
        df["SingularSearchTerm"] = df["Singular"].str.split("[", n=1, expand=True)[0]
        df["PluralSearchTerm"] = df["Plural"].str.split("[", n=1, expand=True)[0]
        df["SingularREP"] = df["Singular"]
        df["PluralREP"] = df["Plural"]
        df["SingularREP"] = df["SingularREP"].replace({"\(": "\\("}, regex=True)
        df["SingularREP"] = df["SingularREP"].replace({"\)": "\\)"}, regex=True)
        df["PluralREP"] = df["PluralREP"].replace({"\(": "\\("}, regex=True)
        df["PluralREP"] = df["PluralREP"].replace({"\)": "\\)"}, regex=True)
        df["SingularREP"] = df["SingularREP"].replace(
            {r"\[a\]": "(?:e|er|es|en)?"}, regex=True
        )
        df["SingularREP"] = df["SingularREP"].replace(
            {r"\[t\]": "(?:der|die|das)?"}, regex=True
        )
        df["SingularREP"] = df["SingularREP"].replace({r"\[p\]": ""}, regex=True)
        df["PluralREP"] = df["PluralREP"].replace(
            {r"\[a\]": "(?:e|er|es|en)?"}, regex=True
        )
        df["PluralREP"] = df["PluralREP"].replace(
            {r"\[t\]": "(?:der|die|das)?"}, regex=True
        )
        df["PluralREP"] = df["PluralREP"].replace({r"\[p\]": ""}, regex=True)
        df["PluralREP"] = df["PluralREP"].replace({r"\[p ": ""}, regex=True)
        df["SingularREP"] = "^" + df["SingularREP"].astype(str) + "$"
        df["PluralREP"] = "^" + df["PluralREP"].astype(str) + "$"
    elif lang == "ja":
        df["SingularSearchTerm"] = df["Singular"]
    df = df.rename(columns={"Singular": "Singular{" + lang + "}"})
    df = df.rename(columns={"Plural": "Plural{" + lang + "}"})
    df = df.rename(columns={"Name": "Name{" + lang + "}"})
    df = df.rename(columns={"SingularSearchTerm": "SingularSearchTerm{" + lang + "}"})
    df = df.rename(columns={"PluralSearchTerm": "PluralSearchTerm{" + lang + "}"})
    df = df.rename(columns={"SingularREP": "SingularREP{" + lang + "}"})
    df = df.rename(columns={"PluralREP": "PluralREP{" + lang + "}"})
    return df


def transform_content_finder_condition():
    df = create_content_finder_condition_df(primary_lang)
    for lang in addl_langs:
        addl_df = create_content_finder_condition_df(lang)
        df = merge_df_exclude_dupes(df, addl_df)
    write_transformed_csv(df, content_finder_condition_dest)


def create_content_finder_condition_df(lang):
    content_finder_condition_src = (
        src_dir + lang + "/" + content_finder_condition_file_name + property_ext
    )
    remove_dummy_headers(content_finder_condition_src, content_finder_condition_dest)
    df = read_csv(content_finder_condition_dest)
    df = rename_key_col(df)
    df["HighEndDuty"] = df["HighEndDuty"].astype(str)
    df = df[df["Name"] != ""]
    df = df[df["Name"].notnull()]
    df = remove_placeholders(df)
    df = remove_unused_cols(df, content_finder_condition_cols)
    df = df.rename(columns={"Name": "Name{" + lang + "}"})
    return df


def transform_territory_type():
    territory_type_src = (
        src_dir + primary_lang + "/" + territory_type_file_name + property_ext
    )
    remove_dummy_headers(territory_type_src, territory_type_dest)
    df = read_csv(territory_type_dest)
    df = rename_key_col(df)
    df = remove_unused_cols(df, territory_type_cols)
    write_transformed_csv(df, territory_type_dest)


def transform_place_name():
    df = create_place_name_df(primary_lang)
    for lang in addl_langs:
        addl_df = create_place_name_df(lang)
        df = merge_df_exclude_dupes(df, addl_df)
    write_transformed_csv(df, place_name_dest)


def create_place_name_df(lang):
    place_name_src = src_dir + lang + "/" + place_name_file_name + property_ext
    remove_dummy_headers(place_name_src, place_name_dest)
    df = read_csv(place_name_dest)
    df = rename_key_col(df)
    df = df[df["Name"] != ""]
    df = df[df["Name"].notnull()]
    df = df[df["Name"] != "???"]
    df = remove_placeholders(df)
    df = remove_unused_cols(df, place_name_cols)
    df = df.rename(columns={"Name": "Name{" + lang + "}"})
    return df


def transform_map():
    map_src = src_dir + primary_lang + "/" + map_file_name + property_ext
    remove_dummy_headers(map_src, map_dest)
    df = read_csv(map_dest)
    df = rename_key_col(df)
    df = remove_unused_cols(df, map_cols)
    write_transformed_csv(df, map_dest)


def transform_language():
    language_custom_data = pd.read_csv("../custom-data/Language.csv")
    write_transformed_csv(language_custom_data, language_dest)


def transform_item_action():
    item_action_src = (
        src_dir + primary_lang + "/" + item_action_file_name + property_ext
    )
    remove_dummy_headers(item_action_src, item_action_dest)
    df = read_csv(item_action_dest)
    df = rename_key_col(df)
    df = remove_unused_cols(df, item_action_cols)
    write_transformed_csv(df, item_action_dest)


# Transform Extracts
transform_class_job()
transform_world()
transform_item()
transform_content_finder_condition()
transform_territory_type()
transform_place_name()
transform_map()
transform_language()
transform_item_action()
