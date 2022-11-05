#pragma once
#include "Student.h"
#include "Unit.h"

class ClassRoom
{
private:
    vector<Student*> _students;
    Unit* _unit;

public:
    ClassRoom(const Unit& unit);
    ClassRoom(const ClassRoom& classroom);
    ~ClassRoom();

    ClassRoom& operator=(const ClassRoom& classroom);


};
