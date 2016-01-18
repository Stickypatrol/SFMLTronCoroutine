open SFML.Window
open SFML.Graphics

let mainWindow = new RenderWindow(new VideoMode(600ul, 600ul), "Empty")
mainWindow.SetFramerateLimit(40ul);
mainWindow.Closed.AddHandler(fun sender args -> (sender :?> RenderWindow).Close())

let rec mainLoop() =
  mainWindow.Clear()
  mainWindow.DispatchEvents()
  mainWindow.Display()

  match mainWindow.IsOpen with
  | true -> mainLoop()
  | false -> ()

mainLoop()