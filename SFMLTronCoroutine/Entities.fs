module Entities

open System
open CoroutineMonad
open Math
open SFML.Graphics
open Input

type Body =
  {
    Health    : int
    Position  : Vector2<p>
    Velocity  : Vector2<p/s>
    Rotation  : float
  } with
  static member Move b (dt:float<s>) =
    {b with Position = b.Position + b.Velocity * dt}

type Message = Map<int, Body -> Body>

type DrawContext = Map<Body, Sprite>

type Entity<'w, 'fs, 'dc> =
  {
    Fields          : 'fs
    Update          : Coroutine<'w, 'fs, bool>
    Draw            : Coroutine<'w*'fs, 'dc, Unit>
    HandleMessages  : Coroutine<'w, 'fs, Unit>
  }

and Player =
  {
    Name    : string
    ID      : int
    Body    : Body
    IB      : InputBehavior<Body>
  }with
  static member Update : Coroutine<World, Player, bool> =
    fun w (s:Player) ->
      let body' = Body.Move s.Body w.DeltaT
      Done(false, {s with Body = body'})
  static member Draw =
    fun (w,s) dc ->
      Done((), dc)
  static member NetworkUpdate =
    fun w s ->
      Done((), s)
    
and Bullet =
  {
    ID      : int
    Body    : Body
    IB      : InputBehavior<Body>
  }with
  static member Update : Coroutine<World, Bullet, bool> =
    fun w (s:Bullet) ->
      let body' = Body.Move s.Body w.DeltaT
      Done(false, {s with Body = body'})
  static member Draw =
    fun (w,s) dc ->
      Done((), dc)

and Obstacle =
  {
    ID      : int
    Body    : Body
    IB      : InputBehavior<Body>
  }with
  static member Update : Coroutine<World, Obstacle, bool> =
    fun w (s:Obstacle) ->
      let body' = Body.Move s.Body w.DeltaT
      Done(false, {s with Body = body'})
  static member Draw =
    fun (w,s) dc ->
      Done((), dc)

and World =
  {
    Time      : float
    DeltaT    : float<s>
    Players   : List<Entity<World, Player, DrawContext>>
    Bullets   : List<Entity<World, Bullet, DrawContext>>
    Obstacles : List<Entity<World, Player, DrawContext>>
    NetworkMessages : List<Message>
  }with
  static member Update : Coroutine<World, World, bool> =
    fun w (s:World) ->
      Done(false, s)
  static member Draw =
    fun (w,s) dc ->
      Done((), dc)