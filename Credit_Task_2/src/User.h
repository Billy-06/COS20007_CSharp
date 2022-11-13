#pragma once

#include <iostream>
#include <string>
#include <vector>

using namespace std;

class User
{
protected:
    string _firstname;
    string _lastname;
    string _password;
    bool _loggedIn;

public:
    User();
    User(string fname, string lname, string password);
    User(const User& user);
    ~User();

    User& operator=(const User& user);

    string getFirstname() const;
    void setFirstname(string value);

    string getLastname() const;
    void setLastname(string value);

    string getPassword() const;
    void setPassword(string value);

    void logIn();
    void logOut();

    virtual void print();
};
