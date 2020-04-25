namespace Template

open Elmish
open Elmish.React

open Fable.Import
open Fable.Core.JsInterop

open Shared

module Client =
    let init () : Model * Cmd<Msg> =
        let model : Model = Browser.Dom.window?__INIT_MODEL__
        model, Cmd.none

    let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
        match currentModel.Counter, msg with
        | Some counter, Increment ->
            let nextModel = { currentModel with Counter = Some { Value = counter.Value + 1 } }
            nextModel, Cmd.none
        | Some counter, Decrement ->
            let nextModel = { currentModel with Counter = Some { Value = counter.Value - 1 } }
            nextModel, Cmd.none
        | _, InitialCountLoaded (Ok initialCount)->
            let nextModel = { Counter = Some initialCount }
            nextModel, Cmd.none

        | _ -> currentModel, Cmd.none

    #if DEBUG
    open Elmish.Debug
    open Elmish.HMR
    #endif

    Program.mkProgram init update view
    #if DEBUG
    |> Program.withConsoleTrace
    #endif
    |> Program.withReactHydrate "elmish-app"
    #if DEBUG
    |> Program.withDebugger
    #endif
    |> Program.run
