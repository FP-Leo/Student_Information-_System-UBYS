import { createBrowserRouter } from "react-router-dom";
import App from "../App"
import Auth from "../pages/auth/auth.jsx"
import MainScreen from "../pages/main-screen/main-screen.jsx";
import NotFound from "../pages/404-notfound.jsx"
import Derslerim from "pages/my-classes/Derslerim";


export const router = createBrowserRouter([
    {
        path:"/",
        Component:App,
        children:[
            { // Auth Page
                path:"/", // path info
                Component:Auth, // which component related with this path
                index:true // This means this path is root's default url 
            },
            { // Main Page
                path:"/home",
                Component: MainScreen
            },
            {
                path: "*",
                Component:NotFound
            },
            {
                path:"/404",
                Component:NotFound
            },
            {
                path:"/derslerim",
                Component:Derslerim
            }
        ]
    }
])