#pragma once

#include <iostream>
#include <string>
#include <vector>

using namespace std;


/**
 * @brief This is an abstract class for users of the grading system. The
 * classes Lecturer::Lecturer and Student::Student inherit from this class.
 *
 */
class User
{
protected:
    /**
     * @brief The user's firstname
     *
     */
    string _firstname;
    /**
     * @brief The user's last name
     *
     */
    string _lastname;
    /**
     * @brief The user's password
     *
     */
    string _password;
    /**
     * @brief The login status of the user
     *
     */
    bool _loggedIn;

public:
    /**
     * @brief Construct a new User object using the default cosntructor
     *
     */
    User();
    /**
     * @brief Construct a new User object using the pass by value constructor
     *
     * @param fname The value to be assigned to the object's first name
     * @param lname The value to be assigned to the object's last name
     * @param password The value to be assigned to the object's password
     */
    User(string fname, string lname, string password);

    /**
     * @brief Construct a new User object using the copy constructor
     *
     * @param user The reference to an existing user object to be copied from
     */
    User(const User& user);

    /**
     * @brief Destroy the User object
     *
     */
    ~User();

    /**
     * @brief Assignment operator for a deep copy of the User object
     *
     * @param user The reference to an existing user object to be copied from
     * @return User object copied from the provided reference to an existing object
     */
    User& operator=(const User& user);

    /**
     * @brief Get the Firstname object
     *
     * @return The user's first name
     */
    string getFirstname() const;

    /**
     * @brief Set the Firstname of the User
     *
     * @param value Value to be assigned as the user's first name
     */
    void setFirstname(string value);

    /**
     * @brief Get the Lastname of the object
     *
     * @return The user's last name
     */
    string getLastname() const;
    /**
     * @brief Set the Lastname User
     *
     * @param value Value to be assigned to the user's last name
     */
    void setLastname(string value);

    /**
     * @brief Get the Password of the User
     *
     * @return The password of the User
     */
    string getPassword() const;
    /**
     * @brief Set the Password of the User
     *
     * @param value Value to be assigned to the User object
     */
    void setPassword(string value);

    /**
     * @brief Get the log in Status object
     *
     * @return a true if logged in or a false if logged out
     */
    bool getStatus();

    /**
     * @brief Change the log in status of the User object to true
     *
     */
    void logIn();
    /**
     * @brief Change the log in status of the User object to false
     *
     */
    void logOut();

    /**
     * @brief Virtual print method to be overriden by inheriting classes. This
     * method, when overriden, is meant to return the Users details
     *
     */
    virtual void print();
};
