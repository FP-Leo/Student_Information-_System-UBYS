import Button from "./Button";
import Paper from "./Paper";
import Tab from "./Tab";
import Tabs from "./Tabs";
import ListItemButton from "./ListItemButton";

export default function ComponentsOverrides(theme) {
  return Object.assign(
    ListItemButton(theme),
    Button(theme),
    Paper(theme),
    Tabs(theme),
    Tab(theme)
  );
}
