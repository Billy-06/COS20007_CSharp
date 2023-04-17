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

int Lecturer::getId()
{
    return _lecturerId;
}
void Lecturer::setId(int value)
{
    _lecturerId = value;
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
                auto unt = studnt.getUnit(unit->getCode());
                auto assessmnt = unt.getAssessment(asmnt->getName());

                assessmnt = *asmnt;

                cout
                << "\n!!!!!!! SUCCESS !!!!!!!"
                << "\nAssessment Details posted successfully." << endl;
            }

        } else {
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

Unit& Lecturer::createUnit(int code, string name, string sem, string desc, int lecId)
{
    Unit* item = new Unit(code, name, sem, desc);
    return *item;

}

void Lecturer::deleteUnit(ClassRoom* clsrom, string unitName, int lecId)
{
    if (_classrooms.size() > 0)
    {
        auto search = find_if(
            _classrooms.begin(),
            _classrooms.end(),
            [&clsrom](ClassRoom* item) { return item->classNumber == clsrom->classNumber;  }
        );

        if (search != _classrooms.end())
        {
            auto findUnit = (*search)->getUnit();
            if (findUnit != nullptr)
            {
                delete findUnit;
                cout
                << "\n!!!!!!!! SUCCESS !!!!!!!!"
                << "\nYou don't appear to have the class in question." << endl;
            }
            else {
                cout
                << "\n!!!!!!!! FAILED !!!!!!!!"
                << "\nThe Unit in question couldn't be found." << endl;
            }
        }
        else {
            cout
            << "\n!!!!!!!! FAILED !!!!!!!!"
            << "\nYou don't appear to have the class in question." << endl;
        }
    }
    else {
        cout
        << "\n!!!!!!!! FAILED !!!!!!!!"
        << "\nYou don't appear to have any classes assigned at this time."
        << "\nConsider assigning somce classes to this lecturer." << endl;
    }
}

void Lecturer::getStudent(ClassRoom* clsrom, int studId, int lecId)
{
    if (lecId > 0)
    {
        if (_classrooms.size() > 0)
        {
            auto search = find_if(
                _classrooms.begin(),
                _classrooms.end(),
                [&clsrom](ClassRoom* item) { return item->classNumber == clsrom->classNumber;  }
            );

            if (search != _classrooms.end())
            {
                try {
                    auto finder = (*search)->getStudent(studId);
                    finder.print();

                } catch (exception e)
                {
                    cout
                    << "\n!!!!!!!! FAILED !!!!!!!!"
                    << "\nStudent not found!!\n" << endl;

                }

            }
        }
        else {
            cout
            << "\n!!!!!!!! FAILED !!!!!!!!"
            << "\nYou don't appear to have any classes assigned at this time."
            << "\nConsider assigning somce classes to this lecturer." << endl;
        }

    }
}

void Lecturer::postGrade(ClassRoom* clsrom, Student* stud, Unit* unit, int lecId)
{

}

void Lecturer::print()
{

}
