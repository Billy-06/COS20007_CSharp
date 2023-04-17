# Student Grading System - Billy Micah 

## Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Objects pre-created](#starter_objects)
- [How to Run the Project](#usage)
- [Contributing](../CONTRIBUTING.md)

## About <a name = "about"></a>

This Project is an implementation of a Student Gradin System in which the student can query the system about: <br/>
* The grade they obtain for certain unit,
* Units that they take for that semester,
* And view unit description. <br/>

The Lecturer can as well access the same information as students, however in addition, the lecturer can;

* create a new unit,
* edit the unit details, 
* create the assessment category, 
* update the students' assessment scores and 
* update the students' grading.

## Getting Started <a name = "getting_started"></a>

This is a CMake project written in CXX version ++17. In order to run this project you'll need cmake installed on your system and C++.

### Prerequisites

- CMake
- C/C++ compiler    (any)
- CMake Tools       (VS code extension from microsoft)
- C/C++             (VS code extension from microsoft)

### Installing

- CMake
- C/C++ compiler (any)

#### Downloading CMake & CXX compiler

For Windows OS, 
- Download the windows executable or .msi file from the <a href="https://cmake.org/install/">CMake</a>
- Download <a href="https://visualstudio.microsoft.com/vs/community/">Visual Studio</a> which comes with the windows C++ compiler.


Unix System
- Follow the CMake installation instructions <a href="https://cmake.org/install/">here</a>
- Follow the installation instructions <a href="https://gasparri.org/2020/07/30/installing-c17-and-c20-on-ubuntu-and-amazon-linux/">on C++ 17 or C++ 20</a>


## Objects already created (include log in passwords) <a name = "starter_objects"></a>

Class Rooms Created
```
    ClassRoom* classrm0 = new ClassRoom();
    
    ClassRoom* classrm1 = new ClassRoom();
    
    ClassRoom* classrm2 = new ClassRoom();
    
    ClassRoom* classrm3 = new ClassRoom();


    classrm0->classNumber = 0020;
    
    classrm1->classNumber = 0021;
    
    classrm2->classNumber = 0022;
    
    classrm3->classNumber = 0023;
```


Lecturers Created
```
    Lecturer* lec0 = new Lecturer( "Jackson", "Kanade", "pass000", 430 );
    
    Lecturer* lec1 = new Lecturer( "Lin", "Wee", "pass001", 431 );
    
    Lecturer* lec2 = new Lecturer( "Nick", "Kosa", "pass002", 432 );
    
    Lecturer* lec3 = new Lecturer( "Meng", "Joe", "pass003", 433 );
```


Units Created
```
    Unit* unit0 = new Unit( 6789, "Object Oriented Programming", "Semester 2", "This course introduces the fundamemntals of Object Oriented Programming");
    
    
    Unit* unit1 = new Unit( 6789, "Web Development", "Semester 2", "This course introduces the fundamemntals of Web Development");
    
    
    Unit* unit2 = new Unit( 6789, "Artificial Intelligence", "Semester 2", "This course introduces the fundamemntals of Artificial Intelligence");
    
    
    Unit* unit3 = new Unit( 6789, "Machine Learning", "Semester 2", "This course introduces the fundamemntals of Machine Learning");
```


Students Created
```
    Student* stud0 =  new Student("Prior", "Kish", "pass00", 340);
    
    Student* stud1 =  new Student("Lin", "Feng", "pass01", 341);
    
    Student* stud2 =  new Student("Micah", "Terk", "pass02", 342);
    
    Student* stud3 =  new Student("Ahmed", "Feng", "pass03", 343);

    stud0->setId(2000);

    stud1->setId(2001);

    stud2->setId(2002);
    
    stud3->setId(2003);

```




## How to run the project <a name = "usage"></a>

I recommend that you use Visual Studio Code to run this code.
- Head to the visual studio Code marketplace by pressing;
```
Ctrl + Shift + X
```
- Search for and install these extensions:
```
CMake Tools (from microsoft)
C/C++ (from microsoft)
```

## Part A: Run the executable
The root folder of this project bears the name Credit_Task_2. This is also the folder that contains the README.md file. Open the root folder in VSCode.

* Navigate to the root folder and to open the terminal in VSCode press
```
Ctrl + `
```

* Create the build folder in the root directory (folder)
```
mkdir build
```

* Navigate into the build dir
```
cd build
```

* Build the project using CMake
```
cmake ..
```
* Build the executable while still in the build dir
```
cmake --build . --target Executable
```

- The above command will generate the executable file whose directory will be mentioned on the last line of the output after the above command. On a Windows machine you can find the executable in the .\application\Debug\Executable.exe
- Paste this into the terminal and press enter to run the executable.
```
.\application\Debug\Executable.exe
```

- The above command will run the project.

## Part B: Run the Unit Tests
This project uses <a href="https://google.github.io/googletest/">Google Tests</a> to run unit tests. If you haven't build the project follow these steps;

* Navigate to the root folder and to open the terminal in VSCode press
```
Ctrl + `
```

* Open the CMakeLists.txt file in the root directory (folder), and change the RUN_TESTS option to ON. Find this option on line 23 of the mentioned file.
```
turn the test on
set(RUN_TESTS           ON)
```

* Delete the build directory manually to rebuild
```
rm -rf build
```

* Create the build folder in the root directory (folder)
```
mkdir build
```

* Navigate into the build dir
```
cd build
```

* Build the project using CMake
```
cmake ..
```
* Build the executable while still in the build dir
```
cmake --build . --target Unit_Tests
```
* Run the tests using CTest
```
ctest -C Debug
```
