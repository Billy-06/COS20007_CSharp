#pragma once
#include "User.h"
#include "ClassRoom.h"

using namespace std;

class Lecturer : public User
{
private:
    vector<ClassRoom*> _classrooms;
    int _lecturerId;

public:
    Lecturer();
    Lecturer(string fname, string lname, string passw, int lecId);
    Lecturer(const Lecturer& lec);
    ~Lecturer();

    Lecturer& operator=(const Lecturer& lec);

    int getId();
    void setId(int value);

    vector<ClassRoom*> getClassroom() const;
    void setClassroom(vector<ClassRoom*> item);

    void assignClass(ClassRoom* item);

    void postResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId);
    void updateResuts(ClassRoom* clsrom, Student* stud, Unit* unit, Assessment* asmnt, int lecId);

    Unit& createUnit(int code, string name, string sem, string desc, int lecId);
    void deleteUnit(ClassRoom* clsrom, string unitName, int lecId);

    /**
     * @brief Get the Student object from a certain class room
     *
     * @param clsrom The classroom in which to find the student
     * @param studId The student to be retrieved from the class room
     * @param lecId The enquiring lecturer ID
     */
    void getStudent(ClassRoom* clsrom, int studId, int lecId);

    /**
     * @brief Post a student's grade on a specific unit
     *
     * @param clsrom The classroom in which to find the student
     * @param stud The student whose grade is to be updated
     * @param unit The unit on which the grade is to be udated
     * @param lecId The posting lecturer's ID
     */
    void postGrade(ClassRoom* clsrom, Student* stud, Unit* unit, int lecId);
    /**
     * @brief This function returns the details of the Lecturer including
     * the classes (s)he has been assigned
     *
     */
    void print();

};
