#pragma once
#include "User.h"
#include "Unit.h"

class Student : public User
{
private:
    int _studentId;
    vector<Unit> _units;

public:
    Student();
    Student(const Student& stud);
    ~Student();

    Student& operator=(const Student& stud);


};
