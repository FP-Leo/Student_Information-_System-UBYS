// third-party
import { merge } from "lodash";

// project import
import Button from "./Button";
import CardContent from "./CardContent";
import IconButton from "./IconButton";
import Tab from "./Tab";
import Tabs from "./Tabs";
import Card from "./Card";
import Typography from "./Typography";

// ==============================|| OVERRIDES - MAIN ||============================== //

export default function ComponentsOverrides(theme) {
  return merge(
    Card(),
    Button(theme),
    CardContent(),
    IconButton(theme),
    Tab(theme),
    Tabs(),
    Typography()
  );
}
