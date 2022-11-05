#include "Unit.h"

Unit::Unit(string name, string sem, string desc)
: _name(name), _semester(sem), _description(desc)
{
    // _assessment = nullptr;
    // _grade = Grade::Fail;
}

Unit::Unit(const Unit& unit)
{
    this->_name = unit._name;
    this->_semester = unit._semester;
    this->_description = unit._description;
    this->_assessment = unit._assessment;
    this->_grade = unit._grade;
}
Unit::~Unit()
{
    delete this;
}

Unit& Unit::operator=(const Unit& unit)
{
    this->_name = unit._name;
    this->_semester = unit._semester;
    this->_description = unit._description;
    this->_assessment = unit._assessment;
    this->_grade = unit._grade;

    return *this;
}

void Unit::setName(string name)
{
    _name = name;
}
string Unit::getName() const
{
    return _name;
}

void Unit::setSemester(string sem)
{
    _semester = sem;
}
string Unit::getSemester() const
{
    return _semester;
}

void Unit::setDescription(string desc)
{
    _description = desc;
}
string Unit::getDescription() const
{
    return _description;
}

void Unit::setAssessment(vector<Assessment*> asmnt)
{
    _assessment = asmnt;
}
vector<Assessment*> Unit::getAssessment() const
{
    return _assessment;
}

void Unit::setGrade(Grade grade)
{
    _grade = grade;
}

Grade Unit::getGrade() const
{
    return _grade;
}
