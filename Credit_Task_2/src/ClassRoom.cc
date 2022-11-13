#include "ClassRoom.h"

ClassRoom::ClassRoom()
{

}
ClassRoom::ClassRoom(const Unit& unit)
{
    *_unit = unit;
}

ClassRoom::ClassRoom(const ClassRoom& classroom)
{
    this->_unit = classroom._unit;
    this->_students = classroom._students;
}

ClassRoom::~ClassRoom()
{
    delete this;
}

ClassRoom& ClassRoom::operator=(const ClassRoom& classroom)
{
    this->_unit = classroom._unit;
    this->_students = classroom._students;

    return *this;
}
bool ClassRoom::operator==(const ClassRoom& classroom)
{
    if (
        this->_unit == classroom._unit &&
        this->_students == classroom._students
    )
    {
        return true;
    }
    else return false;
}

vector<Student*> ClassRoom::getStudents() const
{
    return this->_students;
}

Student& ClassRoom::getStudent(const int studID)
{
    if(_students.size() > 0)
    {
        auto item = find_if(
            _students.begin(),
            _students.end(),
            [&studID](Student* stud) { return stud->getId() == studID; }
        );

        if ( item != _students.end() )
        {
            return **item;
        }
    }
}

void ClassRoom::setStudents(vector<Student*> item)
{
    this->_students = item;
}

Unit* ClassRoom::getUnit() const
{
    return _unit;
}
void ClassRoom::setUnit(Unit* item)
{
    this->_unit = item;
}

void ClassRoom::addStudent(Student* item, int lecId)
{
    if (lecId > 0)
    {
        if (_students.size() > 0)
        {
            auto search = find_if(
                _students.begin(),
                _students.end(),
                [&item](Student* stud) { return stud == item; }
            );

            if (search != _students.end())
            {
                cout
                << "!!!!! FAILED !!!!!"
                << "\nThe student " << item->getFirstname() << " already exists" << endl;
            }
            else {
                _students.push_back(item);

                cout
                << "!!!!! SUCCESS !!!!!"
                << "\nThe student " << item->getFirstname() << " was added successfully" << endl;

            }
        }
        else {
                _students.insert(_students.begin(), item);

                cout
                << "!!!!! SUCCESS !!!!!"
                << "\nThe student " << item->getFirstname() << " was added successfully" << endl;

        }
    }
    else {

        cout
        << "!!!!! FAILED !!!!!"
        << "\nPlease provide a valid Lecturer ID number" << endl;

    }
}
void ClassRoom::addStudent(vector<Student*> item, int lecId)
{
    for_each(
        item.begin(),
        item.end(),
        [this ,&lecId](Student* stud) { this->addStudent(stud, lecId); }
    );
}

void ClassRoom::removeStudent(Student* item, int lecId)
{
    if(_students.size() > 0)
    {
        auto search = find_if(
            _students.begin(),
            _students.end(),
            [&item](Student* stud) { return stud == item; }
        );

        if (search != _students.end())
        {
            _students.erase(search);

            cout
            << "\n!!!!!! SUCCESS !!!!!!"
            << "\nThe student " << item->getFirstname() << " " << item->getLastname()
            << " was successfully removed" << endl;
        }
        else {
            cout
            << "\n!!!!!! FAILED !!!!!!"
            << "\nThe student " << item->getFirstname() << " " << item->getLastname()
            << " was not found in the clasroom list" << endl;

        }
    }
    else {
            cout
            << "\n!!!!!! FAILED !!!!!!"
            << "\nYou appear to have an empty student list in the classroom.\nConsider adding some students" << endl;

    }
}
void ClassRoom::removeStudent(bool clearList, int lecId)
{
    if(_students.size() > 0)
    {
        for(int i=0; i < _students.size(); i++) this->_students.pop_back();

        cout
        << "\n!!!!!! SUCCESS !!!!!!"
        << "\nSuccessfully removed all students from the list" << endl;
    }
    else {
        cout
        << "\n!!!!!! FAILED !!!!!!"
        << "\nYou appear to have an empty student list in the classroom.\nConsider adding some students" << endl;

    }
}

void ClassRoom::print()
{
    cout
    << "\nClass Room Information"
    << "\n======================"
    << "\nClass Room Number: " << classNumber
    << "\nNumber of Students: " << _students.size()
    << "\nStudents Details: " << endl;

    for_each(
        _students.begin(),
        _students.end(),
        [](Student* stud) { stud->print(); }
    );
}
