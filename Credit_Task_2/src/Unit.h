#pragma once

#include <iostream>
#include <string>
#include <vector>

#include "Assessment.h"

using namespace std;


enum Grade
{
    HighDistinction,
    Distinction,
    Credit,
    Pass,
    Fail,
    NotGraded
};


/**
 * @brief This is a Unit::Unit implementation that represents
 *        the subjects taken by students in order to complete
 *        a certain course in University.
 *
 */
class Unit
{
private:
    /**
     * @brief The name of the Unit::Unit object
     *
     */
    string _name;
    /**
     * @brief The semester the Unit::Unit object is to be taken during
     *
     */
    string _semester;
    /**
     * @brief The description of the contents of the Unit::Unit object
     *
     */
    string _description;
    /**
     * @brief The list of units contained in a Unit::Unit object
     *
     */
    vector<Assessment*> _assessment;
    /**
     * @brief The grade assigned to the Unit::Unit aftera student has
     *        completed the unit
     *
     */
    Grade _grade;

public:

    /**
     * @brief Construct a new Unit:: Unit object
     *
     * @param name Intended to be the name of the Unit being initialised
     * @param sem  The semster during which the unit will be taken
     * @param desc A brief descriptin on the unit coverage and its
     *              contents
     */
    Unit(string name, string sem, string desc);

    /**
     * @brief Construct a new Unit:: Unit object
     *
     * @param unit The already created unit meant to be copied by this
     *             copy constructor
     */
    Unit(const Unit& unit);

    /**
     * @brief Destroy the Unit:: Unit object
     *
     */
    ~Unit();

    /**
     * @brief Assignment operator to provide a deep copy of
     *          the Unit::Unit object
     *
     * @param unit The already created unit meant to be copied by this
     *             assignement operator
     * @return Returns a reference to the copy created of
     *         the Unit::Unit object
     */
    Unit& operator=(const Unit& unit);

    /**
     * @brief This applies comparison between the current Unit::Unit object
     * and another Unit::Unit object to check whether these are equal.
     *
     * @param unit The Unit::Unit object to compare with the currrent object
     * @return Returns true if the Unit::Unit objects being compared are equal
     */
    bool operator==(const Unit& unit);

    /**
     * @brief The setter for the Unit::Unit object's name field
     *
     * @param name The value to be assigned as the Unit::Unit object's name
     */
    void setName(string name);

    /**
     * @brief The getter for the Unit::Unit object's name field
     *
     * @return Returns the a string which is the name of the Unit::Unit object
     */
    string getName() const;

    /**
     * @brief The setter for the Unit::Unit object's semseter field
     *
     * @param sem The value to be assigned as the Unit::Unit Semester value
     */
    void setSemester(string sem);

    /**
     * @brief The getter for the Unit::Unit object's semester field
     *
     * @return Returns the a string which is the semester of the Unit::Unit object
     */
    string getSemester() const;

    /**
     * @brief The setter for the Unit::Unit object's description field
     *
     * @param desc The value to be assigned as the Unit::Unit description value
     */
    void setDescription(string desc);
    /**
     * @brief The getter for the Unit::Unit object's description field
     *
     * @return Returns the a string which is the description of the Unit::Unit object
     */
    string getDescription() const;

    /**
     * @brief The setter for the Unit::Unit object's assessment field
     *
     * @param asmnt The value to be assigned as the Unit::Unit assessment value
     */
    void setAssessment(vector<Assessment*> asmnt);

    /**
     * @brief The getter for the Unit::Unit object's assessment field
     *
     * @return Returns a vector<Assesment*> which is the Assessment of the Unit::Unit object
     */
    vector<Assessment*> getAssessment() const;

    /**
     * @brief The setter for the Unit::Unit object's grade field
     *
     * @param grade The value to be assigned as the Unit::Unit grade value
     */
    void setGrade(Grade grade);

    /**
     * @brief The getter for the Unit::Unit object's grade field
     *
     * @return Returns a Grade type which is the grade of the Unit::Unit object
     */
    Grade getGrade() const;

     /**
     * @brief Add an assessment to the list of assessments in the Unit::Unit object.
     * Pass an Assessment* pointer
     *
     * @param assmnt The pointer to the Assessment::Assessment object
     * @param lecturerId The ID of the lecturer to the Unit::Unit object
     */
    void addAssessment(Assessment* assmnt, int lecturerId);

    /**
     * @brief Get the Assessment object
     *
     * @param assmntName provide the name of the assessment to be retrieved
     * @return Returns a pointer to the Assessment object found in the list
     * of assessments contained in the unit.
     */
    Assessment& getAssessment(string assmntName);

    /**
     * @brief remove an assessment to the list of assessments in the Unit::Unit object.
     * Pass a string value as the name of the assessment object.
     *
     * @param assmntName The name of the Assessment::Assessment object
     * @param lecturerId The ID of the lecturer to the Unit::Unit object
     */
    void removeAssessment(string assmntName, int lecturerId);

    /**
     * @brief Display to the student the details permissible for students to view
     *
     * @param studId The student ID of the student Enquiring about the Unit.
     */
    void display(int studId);

    /**
     * @brief The print statement to be used by the lecturer in printing out
     * the units details in their entirity.
     *
     */
    void print();

};
