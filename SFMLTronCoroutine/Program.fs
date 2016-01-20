open SFML.Window
open SFML.Graphics

open Game

let mainWindow = new RenderWindow(new VideoMode(1500ul, 900ul), "Empty")
mainWindow.SetFramerateLimit(40ul);
mainWindow.Closed.AddHandler(fun sender args -> (sender :?> RenderWindow).Close())

MainLoop mainWindow