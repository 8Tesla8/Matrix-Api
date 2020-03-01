# Matrix-Api

## Short info
Solution contains two project: "api" and "unit test". Api can create matrix any demesnion with random numbers and rotate that matrix on 90 degree and store it in csv file. 
Unit test covered all classes that used in api project except controller.

### Api
Frameworks: .Net core and Autofac(Dependency injection)
Controller: MatrixController
Get methods description: 
1. "/matrix" or "/matrix?demension={value}"
Get method generate matrix with random numbers in it and save that matrix in csv file. Default demension value is 4. User can pass demension value in get method by querry parameter, controller will generate matrix with passed demension value. Every query save matrix in csv file (matrix.csv). 
2. "/matrix/rotate"
Get method that rotate saved matrix in "matrix.csv", after rotation new matris also saved in csv file (matrix.csv). 
Additional files: "matrix.csv" in api project.

### Tests
Frameworks: Nunit(Unit tests), Moq(Create moq objects) and Autofac(Dependency injection)
Functionality:
Additional: Api controller not covered unit tests because controller does not have additional functionality it use other classes that already covered by unit test  
Additional files: "TestFiles" folder contains different csv files for different unit tests.
