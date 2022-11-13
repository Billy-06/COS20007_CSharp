#include "Student.h"
#include <algorithm>

Student::Student() : User()
{
    _studentId = 0;
}

Student::Student(string fname, string lname, string password, int studentId)
: User(fname, lname, password), _studentId(studentId)
{
    Unit* webDev = new Unit(
        "Web Development",
        "Semester 2",
        "This unit covers advanced topics in web development"
    );
    _units.insert(_units.begin(), webDev);
}
Student::Student(const Student& stud)
{
    this->_firstname = stud._firstname;
    this->_lastname = stud._lastname;
    this->_password = stud._password;
    this->_loggedIn = stud._loggedIn;
    this->_studentId = stud._studentId;
    this->_units = stud._units;
}
Student::~Student()
{
    delete this;
}

Student& Student::operator=(const Student& stud)
{
    this->_firstname = stud._firstname;
    this->_lastname = stud._lastname;
    this->_password = stud._password;
    this->_loggedIn = stud._loggedIn;
    this->_studentId = stud._studentId;
    this->_units = stud._units;

    return *this;
}

bool Student::operator==(const Student& stud)
{
    if (
        this->_firstname == stud._firstname &&
        this->_lastname == stud._lastname &&
        this->_password == stud._password &&
        this->_loggedIn == stud._loggedIn &&
        this->_studentId == stud._studentId &&
        this->_units == stud._units
    )
    {
        return true;
    }
    else {
        return false;
    }
}

void Student::viewGrade(int studentId, string unitName) const
{
    if (studentId == _studentId)
    {
        if (_units.size() > 0)
        {
            auto search = find_if(
                _units.begin(),
                _units.end(),
                [&unitName](Unit* item) { return item->getName() == unitName; }
            );
            if (search != _units.end()) (*search)->display(studentId);
            else cout << "Unit with the name " << unitName << " was not found" << endl;
        }
        else
        {
            cout << "\nNo units added just yet. Consider adding some units" << endl;
        }
    }
}

vector<Unit*> Student::semesterUnits() const
{
    return _units;
}

Unit& Student::getUnit(string unitName)
{
    if (_units.size() > 0)
    {
        auto search = find_if(
            _units.begin(),
            _units.end(),
            [&unitName](Unit* item) { return item->getName() == unitName; }
        );

        if(search != _units.end()) return **search;
    }
}

int Student::getId() const
{
    return _studentId;
}
void Student::setId(int value)
{
    _studentId = value;
}

void Student::addUnit(Unit* unit)
{
    auto checker = find_if(
        _units.begin(),
        _units.end(),
        [&unit](Unit* item){ return (*item) == *unit; }
    );
    if (checker != _units.end())
    {
        (_units.size() > 0)
            ? _units.push_back(unit)
            : _units.insert(_units.begin(), unit);
        cout
        << "!!!!!!!!!  SUCCESS !!!!!!!"
        << "\nYou've successfully added" << unit->getName() << endl;
    }
    else {
        cout
        << "!!!!!!!!!  FAILED !!!!!!!"
        << "\nYou appear to already have " << unit->getName() << ". You can only have one class for each unit" << endl;
    }
}

void Student::removeUnit(Unit* unit)
{
    auto checker = find_if(
        _units.begin(),
        _units.end(),
        [&unit](Unit* item){ return (*item) == *unit; }
    );
    if (checker != _units.end())
    {

        _units.erase(checker);

        cout
        << "!!!!!!!!!  SUCCESS !!!!!!!"
        << "\nYou've successfully removed " << unit->getName() << endl;
    }
    else {
        cout
        << "!!!!!!!!!  FAILED !!!!!!!"
        << "\nYou appear to not to have " << unit->getName() << endl;
    }
}

void Student::print()
{
    string status = (this->_loggedIn) ? "Logged In" : "Logged Out";

    cout
    << "\nName: " << this->_firstname << " " << this->_lastname
    << "\nStatus: " << status
    << "\nUnits: "
    << "==================" << endl;

    for_each(
        _units.begin(),
        _units.end(),
        [](Unit* item) { item->print(); }
    );

}
