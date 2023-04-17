#include "Unit.h"
#include <algorithm>

using namespace std;

Unit::Unit(int code, string name, string sem, string desc)
: _code(code), _name(name), _semester(sem), _description(desc)
{

    _grade = (Grade)5;
}


Unit::Unit(const Unit& unit)
{
    this->_code = unit._code;
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
    this->_code = unit._code;
    this->_name = unit._name;
    this->_semester = unit._semester;
    this->_description = unit._description;
    this->_assessment = unit._assessment;
    this->_grade = unit._grade;

    return *this;
}

bool Unit::operator==(const Unit& unit)
{
    if (
        this->_code == unit._code &&
        this->_name == unit._name &&
        this->_semester == unit._semester &&
        this->_description == unit._description &&
        this->_assessment == unit._assessment &&
        this->_grade == unit._grade
    )
    {
        return true;
    }
    else return false;
}

Assessment& Unit::getAssessment(string assmntName)
{
    if(_assessment.size() > 0)
    {
        auto search = find_if(
            _assessment.begin(),
            _assessment.end(),
            [&assmntName](Assessment* item) { return item->getName() == assmntName; }
        );

        if (search != _assessment.end()) return **search;
    }
}

int Unit::getCode()
{
    return _code;
}

void Unit::setCode(int value)
{
    _code = value;
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

void Unit::addAssessment(Assessment* assmnt, int lecturerId)
{
    if (_assessment.size() == 0 )
    {
        _assessment.insert(_assessment.begin(), assmnt);
    }
    else {
        _assessment.push_back(assmnt);
    }
    cout << assmnt->getName() << "Has been added successfully" << endl;
}

void Unit::removeAssessment(string assmntName, int lecturerId)
{
    if(_assessment.begin() == _assessment.end() || _assessment.size() == 0) {
        cout << "\nYou don't have any assessments yet, consider adding some" << endl;
    }
    else
    {
        auto assessment = find_if(
            _assessment.begin(),
            _assessment.end(),
            [&assmntName](Assessment* item) { return item->getName() == assmntName; }
        );

        if (assessment != _assessment.end())
        {
            _assessment.erase(assessment);

            cout << "\n!!!!!!!! SUCCESS !!!!!!!!"
            << "\nAssessment with the name " << assmntName << " removed." << endl;
        }
        else {
            cout << "\n!!!!!!!! FAILED !!!!!!!!"
            << "\nNo Assessment with the name " << assmntName << " was found." << endl;
        }
    }

}


void Unit::display(int studId)
{
    if (studId > 0)
    {
        cout << "\nName: " << this->_name
        << "\nSemester: " << this->_semester
        << "\nDescription: " << this->_description
        << "\nGrade: " << this->_grade
        << "\nAssessments:\n"
        << "=================\n";

        for_each(
            _assessment.begin(),
            _assessment.end(),
            [](Assessment* item) { item->print(); }
        );

    }
    else {
        cout << "\n!!!!!!!! FAILED !!!!!!!!"
            << "\nNo Student with an ID: " << studId << " was found." << endl;
    }
}

void Unit::appPrint()
{
    cout << "\nUnit Code: " << this->_code
    << "\nName: " << this->_name
    << "\nSemester: " << this->_semester
    << "\nDescription: " << this->_description
    << "\nAssessments:\n"
    << "=================\n";
    if (_assessment.size() > 0)
    {
        for_each(
            _assessment.begin(),
            _assessment.end(),
            [](Assessment* item) { item->print(); }
        );
    }
    else cout << "No Assessments added yet." << endl;
}

void Unit::print()
{
    string gradePrint;
    switch (this->_grade)
    {
    case 0:
        gradePrint = "High Distinction";
        break;
    case 1:
        gradePrint = "Distinction";
        break;
    case 2:
        gradePrint = "Credit";
        break;
    case 3:
        gradePrint = "Pass";
        break;
    case 4:
        gradePrint = "Fail";
        break;

    default:
        gradePrint = "Not Graded Yet";
        break;
    }

    cout << "\nUnit Code: " << this->_code
        << "\nName: " << this->_name
        << "\nSemester: " << this->_semester
        << "\nDescription: " << this->_description
        << "\nGrade: " << gradePrint
        << "\nAssessments:\n"
        << "=================\n";
        if (_assessment.size() > 0)
        {
            for_each(
                _assessment.begin(),
                _assessment.end(),
                [](Assessment* item) { item->print(); }
            );
        }
        else cout << "No Assessments added yet." << endl;
}
