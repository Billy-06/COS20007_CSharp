#include "Lecturer.h"

Lecturer::Lecturer(string fname, string lname, string passw, int lecId)
: User::User(fname, lname, passw), _lecturerId(lecId)
{

}

Lecturer::Lecturer(const Lecturer& lec)
{
    User::_firstname = lec._firstname;
    User::_lastname = lec._lastname;
    User::_password = lec._password;
    this->_lecturerId = lec._lecturerId;
}

Lecturer::~Lecturer()
{
    delete this;
}

Lecturer& Lecturer::operator=(const Lecturer& lec)
{
    User::_firstname = lec._firstname;
    User::_lastname = lec._lastname;
    User::_password = lec._password;
    this->_lecturerId = lec._lecturerId;

    return *this;
}

void Lecturer::postResuts(Student stud, Assessment asmnt, int lecId)
{

}

string Lecturer::updateResuts(Student stud, Assessment asmnt, int lecId)
{

}

Unit& Lecturer::createUnit()
{

}

string Lecturer::updateUnit()
{

}

void Lecturer::deleteUnit()
{

}

void Lecturer::getStudent(int studId, int lecId)
{

}

void Lecturer::postGrade(Student stud, Unit unit, int lecId)
{

}

string Lecturer::print()
{

}
