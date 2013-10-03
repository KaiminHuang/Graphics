Graphic and Interaction project 1
kaiminh
514929
====================================================================================================================
The plasma fractal function in this application using the program from "http://jseyster.github.io/plasmafractal/"
====================================================================================================================
Implementation description:
1. set the four conors of the landscape, set the pix size
2. create 4 random number as the height of the four cornors of landscape
3. using a recursive function called "DividGrid", to divid the landscape until the grid width is smaller than the pix size
4. GetColor function will be called to set the color of vecters
5. the DividGrid function will return a buffer, in which all grids' cornors are stored
6. application read all vectors from the buffer and show them on screen
