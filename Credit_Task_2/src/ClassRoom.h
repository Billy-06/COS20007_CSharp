#pragma once
#include "Student.h"
#include "Unit.h"
#include <algorithm>

class ClassRoom
{
private:
    vector<Student*> _students;
    Unit* _unit;

public:
    int classNumber;

    ClassRoom();
    ClassRoom(const Unit& unit);
    ClassRoom(const ClassRoom& classroom);
    ~ClassRoom();

    ClassRoom& operator=(const ClassRoom& classroom);
    bool operator==(const ClassRoom& classroom);

    vector<Student*> getStudents() const;
    void setStudents(vector<Student*> item);

    Unit* getUnit() const;
    void setUnit(Unit* item);

    void addStudent(Student* item, int lecId);
    void addStudent(vector<Student*> item, int lecId);
    void removeStudent(Student* item, int lecId);
    void removeStudent(bool clearList, int lecId);

    Student& getStudent(const int studID);

    void print();

};
