#include "Assessment.h"

Assessment::Assessment()
{
    this->_name = "";
    this->_startDate = "";
    this->_dueDate = "";
    this->_description = "";
    this->_feedback = "";
    this->_open = false;
    this->_category = Category::PassTask;
    this->_score = 0;
}

Assessment::Assessment(string name, string startDate, string dueDate, string description, Category category)
: _name(name), _startDate(startDate), _dueDate(dueDate), _description(description), _category(category)
{
    _feedback = "";
    _open = false;
    _score = 0;
}
Assessment::Assessment(const Assessment& item)
{
    this->_name = item._name;
    this->_startDate = item._startDate;
    this->_dueDate = item._dueDate;
    this->_description = item._description;
    this->_feedback = item._feedback;
    this->_open = item._open;
    this->_category = item._category;
    this->_score = item._score;
}

Assessment::~Assessment()
{
    delete this;
}

Assessment& Assessment::operator=(const Assessment& item)
{
    this->_name = item._name;
    this->_startDate = item._startDate;
    this->_dueDate = item._dueDate;
    this->_description = item._description;
    this->_feedback = item._feedback;
    this->_open = item._open;
    this->_category = item._category;
    this->_score = item._score;

    return *this;
}

void Assessment::setName(string name)
{
    _name = name;
}
string Assessment::getName() const
{
    return _name;
}

void Assessment::setStartDate(string startDate)
{
    _startDate = startDate;
}
string Assessment::getStartDate() const
{
    return _startDate;
}

void Assessment::setDueDate(string dueDate)
{
    _dueDate = dueDate;
}
string Assessment::getDueDate() const
{
    return _dueDate;
}

void Assessment::setFeedback(string feedbk)
{
    _feedback = feedbk;
}
string Assessment::getFeedback() const
{
    return _feedback;
}

void Assessment::setDesc(string desc)
{
    _description = desc;
}
string Assessment::getDesc() const
{
    return _description;
}

void Assessment::setCategory(Category catgry)
{
    _category = catgry;
}
Category Assessment::getCategory() const
{
    return _category;
}

void Assessment::setScore(int score)
{
    _score = score;
}
int Assessment::getScore() const
{
    return _score;
}

void Assessment::updateAssessment(int lectureId, Assessment assmnt)
{
    if (lectureId > 0)
    {
        _name = assmnt._name;
        _startDate = assmnt._startDate;
        _dueDate = assmnt._dueDate;
        _description = assmnt._description;
        _feedback = assmnt._feedback;
        _open = assmnt._open;
        _category = assmnt._category;
        _score = assmnt._score;

        cout << "Assessment details updated successfully";
    }
    else cout << "Please Provide a valid Lecturer ID Number";
}

void Assessment::closeAvailability()
{
    if (_open == true) _open = false;

    cout << "The Assessment is now NOT Available"<< endl;
}
void Assessment::makeAvailabile()
{
    if (_open == false) _open = true;
    cout << "The Assessment is now Available" << endl;
}

void Assessment::print()
{

    if (this->_name == "")
    {
        string status = (_open == true) ? "Available" : "Not Available";
        _feedback = (_open = true) ? "--Yet to be checked--" : _feedback;

        cout
        << "\nName: " << _name
        << "\nCategory: " << _category
        << "\nAvailable: " << status
        << "\nStart Date: " << _startDate
        << "\nEnd Date: " << _dueDate
        << "\nDescription: " << _description
        << "\n==================="
        << "\nScore: " << _score
        << "\n==================="
        << "\nFeedback: " << _feedback << endl;
    }
    else {
        cout
        << "\nNo assessment added. Please consider adding some Assessments" << endl;
    }
}
