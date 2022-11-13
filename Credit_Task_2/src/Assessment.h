#pragma once
#include <iostream>
#include <string>
// #include "DateTime.h"

using namespace std;

enum Category
{
    PassTask,
    CreditTask,
    DistinctionTask,
    HDTask,
    GroupWork,
    OnlineTest
};

class Assessment
{
private:
    string _name;
    string _startDate;
    string _dueDate;
    string _feedback;
    string _description;
    bool _open;
    Category _category;
    int _score;

public:
    Assessment();
    Assessment(string name, string startDate, string dueDate, string description, Category category);
    Assessment(const Assessment& item);
    ~Assessment();

    Assessment& operator=(const Assessment& item);

    void setName(string name);
    string getName() const;

    void setStartDate(string startDate);
    string getStartDate() const;

    void setDueDate(string dueDate);
    string getDueDate() const;

    void setFeedback(string feedbk);
    string getFeedback() const;

    void setDesc(string desc);
    string getDesc() const;

    void setCategory(Category catgry);
    Category getCategory() const;

    void setScore(int score);
    int getScore() const;

    void updateAssessment(int lectureId, Assessment assmnt);

    void closeAvailability();
    void makeAvailabile();

    void print();

};
