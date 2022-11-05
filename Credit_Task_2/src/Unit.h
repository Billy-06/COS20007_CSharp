#pragma once

#include <iostream>
#include <string>
#include <vector>

#include "Assessment.h"

using namespace std;

class Unit
{
private:
    string _name;
    string _semester;
    string _description;
    vector<Assessment*> _assessment;
    Grade _grade;

public:
    Unit(string name, string sem, string desc);
    Unit(const Unit& unit);
    ~Unit();

    Unit& operator=(const Unit& unit);

    void setName(string name);
    string getName() const;

    void setSemester(string sem);
    string getSemester() const;

    void setDescription(string desc);
    string getDescription() const;

    void setAssessment(vector<Assessment*> asmnt);
    vector<Assessment*> getAssessment() const;

    void setGrade(Grade grade);
    Grade getGrade() const;

};

enum Grade
{
    HighDistinction,
    Distinction,
    Credit,
    Pass,
    Fail
};
