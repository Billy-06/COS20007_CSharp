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

    void logIn();
    void logOut();

    virtual string print();
};
