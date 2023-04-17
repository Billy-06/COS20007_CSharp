#include "User.h"

User::User()
{
    this->_firstname = "";
    this->_lastname = "";
    this->_password = "";
    this->_loggedIn = false;
}


User::User(string fname, string lname, string password)
: _firstname(fname), _lastname(lname), _password(password)
{
    _loggedIn = false;
}

User::User(const User& user)
{
    this->_firstname = user._firstname;
    this->_lastname = user._lastname;
    this->_password = user._password;
    this->_loggedIn = user._loggedIn;
}

User::~User()
{
    delete this;
}

User& User::operator=(const User& user)
{
    this->_firstname = user._firstname;
    this->_lastname = user._lastname;
    this->_password = user._password;
    this->_loggedIn = user._loggedIn;

    return *this;
}

string User::getFirstname() const
{
    return _firstname;
}
void User::setFirstname(string value)
{
    _firstname = value;
}

string User::getLastname() const
{
    return _lastname;
}
void User::setLastname(string value)
{
    _lastname = value;
}

string User::getPassword() const
{
    return _password;
}
void User::setPassword(string value)
{
    _password = value;
}

bool User::getStatus()
{
    return _loggedIn;
}

void User::logIn()
{
    _loggedIn = true;
}
void User::logOut()
{
    _loggedIn = false;
}

void User::print()
{
    string status = (_loggedIn) ? "Logged In" : "Logged Out";

    cout
        << "\nFirst Name: " <<  _firstname
        << "\nLastName: " << _lastname
        << "\nPassword: " << _password
        << "\nLog In Status: " << status;
}
