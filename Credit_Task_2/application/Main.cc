#include <iostream>
// #include "Lecturer.h"
#include "ClassRoom.h"
#include "Assessment.h"

int main()
{
    // Lecturer* lec = new Lecturer();
    ClassRoom* clsRoom = new ClassRoom();
    Unit* unit = new Unit(
        "Web Development",
        "Semester 2",
        "This unit covers the basics of web development"
    );

    Student* stud0 = new Student("Joe", "Micky", "pass000", 3004);
    Student* stud1 = new Student("Beau", "Kanade", "pass001", 3014);
    Student* stud2 = new Student("Layla", "Feng", "pass002", 3024);
    Student* stud3 = new Student("Ahmed", "Mike", "pass003", 3034);

    clsRoom->addStudent(stud0,2);
    clsRoom->addStudent(stud1,2);
    clsRoom->addStudent(stud2,2);
    clsRoom->addStudent(stud3,2);

    clsRoom->classNumber = 301;
    clsRoom->setUnit(unit);

    clsRoom->print();

    delete unit;

    delete stud0;
    delete stud1;
    delete stud2;
    delete stud3;

    delete clsRoom;

    return 0;
}
