#include "Lecturer.h"

Lecturer::Lecturer(): User()
{
    _lecturerId = 0;
}

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
    this->_classrooms = lec._classrooms;
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
    this->_classrooms = lec._classrooms;

    return *this;
}

vector<ClassRoom*> Lecturer::getClassroom() const
{
    return _classrooms;
}

void Lecturer::setClassroom(vector<ClassRoom*> item)
{
    _classrooms = item;
}

void Lecturer::assignClass(ClassRoom* item)
{
    if (_classrooms.size() > 0)
    {
        auto search = find_if(
            _classrooms.begin(),
            _classrooms.end(),
            [&item](ClassRoom* cls) { return cls->classNumber == item->classNumber; }
        );
        if (search != _classrooms.end())
        {
            cout
            << "!!!!!!! FAILED !!!!!!"
            << this->getFirstname() << " has already been assigned the class "
            << item->classNumber << endl;
        } else{
            _classrooms.push_back(item);
        }
    }
    else {
        _classrooms.insert(_classrooms.begin(), item);
    }
}

void Lecturer::postResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId)
{
    if (lecId == this->_lecturerId )
    {
        if (_classrooms.size() > 0)
        {
            auto clsSearch = find_if(
                _classrooms.begin(),
                _classrooms.end(),
                [&clsrom](ClassRoom* item) { return item == clsrom; }
            );

            if (clsSearch != _classrooms.end())
            {
                auto studnt = (**clsSearch).getStudent(stud->getId());
                auto unt = studnt.getUnit(unit->getName());
                auto assessmnt = unt.getAssessment(asmnt->getName());

                assessmnt = *asmnt;

                cout
                << "\n!!!!!!! SUCCESS !!!!!!!"
                << "\nAssessment Details posted successfully." << endl;
            }
        }
        else {
            cout
            << "\n!!!!!!! FAILED !!!!!!!"
            << "\n" << this->getFirstname() << " " << this->getLastname()
            << " appears not to have any classes assigend."
            << "\nPlease consider assigning some classes." << endl;
        }
    } else {
            cout
            << "\n!!!!!!! FAILED !!!!!!!"
            << "\nPlease enter the right Lecturer ID" << endl;
    }
}

void Lecturer::updateResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId)
{
    this->postResuts(clsrom, stud, unit, asmnt, lecId);
}

Unit& Lecturer::createUnit(string name, string sem, string desc, int lecId)
{
    Unit* item = new Unit(name, sem, desc);
    return *item;

}

string Lecturer::updateUnit(string oldUnitName, Unit* newUnit, int lecId)
{
    return "";
}

void Lecturer::deleteUnit(string unitName, int lecId)
{

}

void Lecturer::getStudent(int studId, int lecId)
{

}

void Lecturer::postGrade(Student* stud, Unit* unit, int lecId)
{

}

void Lecturer::print()
{

}
