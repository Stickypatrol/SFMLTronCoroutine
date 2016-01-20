module Input

open SFML.Window
open SFML.Audio
open SFML.Graphics
open SFML.System

//change the input to work with SFML

type InputBehavior<'a> = Map<int, 'a -> 'a>


(*
let checkRightButton mouselist =
    if Mouse.GetState().LeftButton = ButtonState.Pressed then
        MouseInput.RightButton::mouselist
    else
        mouselist
    
let checkMiddleButton mouselist =
    if Mouse.GetState().LeftButton = ButtonState.Pressed then
        checkRightButton (MouseInput.MiddleButton::mouselist)
    else
        checkRightButton mouselist

let checkLeftButton () =
    if Mouse.GetState().LeftButton = ButtonState.Pressed then
        checkMiddleButton [MouseInput.LeftButton]
    else
        checkMiddleButton []

let processInput (behavior : InputBehavior<'a, 'b>) =
    fun elem dt ->
        let KBinput = List.ofArray <| Keyboard.GetState().GetPressedKeys()
        List.fold (fun elem key ->
                       match (behavior.TryFind <| key) with
                       | Some func -> func elem dt
                       | None -> elem) elem KBinput
*)