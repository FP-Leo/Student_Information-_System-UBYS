import Button from "./Button";
import Paper from "./Paper";
import Tab from "./Tab";
import Tabs from "./Tabs";

export default function ComponentsOverrides(theme) {
  return Object.assign(Button(theme), Paper(theme), Tabs(theme), Tab(theme));
}
