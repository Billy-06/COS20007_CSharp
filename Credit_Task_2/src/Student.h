#pragma once
#include "User.h"
#include "Unit.h"

class Student : public User
{
private:
    /**
     * @brief This is the student ID of the Student::Student object
     *
     */
    int _studentId;

    /**
     * @brief This represents the list of units that a student
     * would be taking in a given sememster. These objects
     * are of type Unit::Unit.
     *
     */
    vector<Unit*> _units;

public:
    Student();
    Student(string fname, string lname, string password, int studentId);
    Student(const Student& stud);
    ~Student();

    int getId() const;
    void setId(int value);

    Unit& getUnit(int unitCode);

    Student& operator=(const Student& stud);
    bool operator==(const Student& stud);
    void viewGrade(int studentId,string unitName) const;
    vector<Unit*> semesterUnits() const;
    void addUnit(Unit* unit);
    void removeUnit(Unit* unit);

    void printUnits();
    void print() override;

};
