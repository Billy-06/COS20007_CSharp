#pragma once
#include "User.h"
#include "ClassRoom.h"

using namespace std;

class Lecturer : public User
{
private:
    vector<ClassRoom*> _classroom;
    int _lecturerId;

public:
    Lecturer(string fname, string lname, string passw, int lecId);
    Lecturer(const Lecturer& lec);
    ~Lecturer();

    Lecturer& operator=(const Lecturer& lec);

    void postResuts(Student stud, Assessment asmnt, int lecId);
    string updateResuts(Student stud, Assessment asmnt, int lecId);

    Unit& createUnit();
    string updateUnit();
    void deleteUnit();
    void getStudent(int studId, int lecId);
    void postGrade(Student stud, Unit unit, int lecId);
    string print();

};
