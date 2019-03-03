/*
 * This program is free software; you can redistribute it and/or modify it under the terms of the
 * GNU General Public License as published by the Free Software Foundation; either version 2 of the
 * License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program; if
 * not, see http://www.gnu.org/licenses/
 */
package uk.ac.cam.cl.kilo.data;

import java.util.List;

/**
 * UserProfile.java
 *
 * @author Nathan Corbyn
 */
public class UserProfile {
  @SuppressWarnings("unused")
  private long id;

  @SuppressWarnings("unused")
  private String name;

  @SuppressWarnings("unused")
  private List<Achievement> achievements;

  @SuppressWarnings("unused")
  private List<Event> interested;

  /**
   * Construct a user profile wrapper object from a given {@link User user}.
   *
   * @param user the user to construct the profile for
   * @throws DatabaseException if the database could not be accessed
   */
  public UserProfile(User user) throws DatabaseException {
    id = user.getID();
    name = user.getName();
    achievements = user.getAchievements();
    interested = user.getMarkedEvents();
  }
}
