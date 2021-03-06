﻿namespace Template

open Shared
open Fable.React
open Fable.React.Props

module Server =
    let rand = System.Random()

    let initialModel () = { Counter = Some { Value = rand.Next(0, 50) } }
    
    let makeInitialHtml model =
        html [ ] [
            head [ ] [
                title [ ] [ str "SAFE Template" ]
                meta [ CharSet "utf-8" ]
                meta [ Name "viewport"; HTMLAttr.Content "width=device-width, initial-scale=1" ]
                link [ Rel "stylesheet"; Href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.7.1/css/bulma.min.css" ]
                link [
                  Rel "stylesheet"
                  Href "https://use.fontawesome.com/releases/v5.6.1/css/all.css"
                  Integrity "sha384-gfdkjb5BdAXd+lj+gudLWI+BXq4IuLW5IT+brZEZsLFm++aCMlF1V92rMkPaX4PP"
                  CrossOrigin "anonymous" ]
                link [ Href "https://fonts.googleapis.com/css?family=Open+Sans"; Rel "stylesheet" ]
                link [ Rel "shortcut icon"; Type "image/png"; Href "/favicon.png" ] ]
            body [ ] [
                div [ Id "elmish-app" ] [ Shared.view model ignore ]
                script [ ] [ RawText (sprintf "var __INIT_MODEL__ = %s" (Thoth.Json.Encode.Auto.toString(0,model))) ]
                script [ Src "./bundle.js" ] [ ] ] ]