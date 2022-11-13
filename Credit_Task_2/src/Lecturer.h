#pragma once
#include "User.h"
#include "ClassRoom.h"

using namespace std;

class Lecturer : public User
{
private:
    vector<ClassRoom*> _classrooms;
    int _lecturerId;

public:
    Lecturer();
    Lecturer(string fname, string lname, string passw, int lecId);
    Lecturer(const Lecturer& lec);
    ~Lecturer();

    Lecturer& operator=(const Lecturer& lec);

    vector<ClassRoom*> getClassroom() const;
    void setClassroom(vector<ClassRoom*> item);

    void assignClass(ClassRoom* item);

    void postResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId);
    void updateResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId);

    Unit& createUnit(string name, string sem, string desc, int lecId);
    string updateUnit(string oldUnitName, Unit* newUnit, int lecId);
    void deleteUnit(string unitName, int lecId);
    void getStudent(int studId, int lecId);
    void postGrade(Student* stud, Unit* unit, int lecId);
    void print();

};
