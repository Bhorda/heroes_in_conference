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

import java.io.File;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import org.dbunit.IDatabaseTester;
import org.dbunit.JdbcDatabaseTester;
import org.dbunit.dataset.IDataSet;
import org.dbunit.dataset.xml.FlatXmlDataSetBuilder;
import org.dbunit.operation.DatabaseOperation;

/**
 * DataTestFramework.java
 *
 * @author Nathan Corbyn
 */
public class DataTestFramework {
  private static final String DATASET = "dataset.xml";
  private static final String AUTOINC =
      "GENERATED BY DEFAULT AS IDENTITY (START WITH 0, INCREMENT BY 1)";

  private static IDatabaseTester databaseTester;

  /** Sets up a database test envinroment using 'dataset.xml'. */
  public static void setup() throws Exception {
    databaseTester =
        new JdbcDatabaseTester(
            org.hsqldb.jdbcDriver.class.getName(), "jdbc:hsqldb:file:data/testdb", "sa", "");
    setupSchema(databaseTester.getConnection().getConnection());
    IDataSet dataSet = new FlatXmlDataSetBuilder().build(new File(DATASET));
    databaseTester.setDataSet(dataSet);
    databaseTester.setSetUpOperation(DatabaseOperation.CLEAN_INSERT);
    databaseTester.setTearDownOperation(DatabaseOperation.DELETE_ALL);
    databaseTester.onSetup();
  }

  private static void setupSchema(Connection conc) throws SQLException {
    PreparedStatement stmt = conc.prepareStatement("DROP SCHEMA PUBLIC CASCADE");
    stmt.execute();
    // Create the content groups table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + ContentGroup.TABLE
                + " ("
                + ContentGroup.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + ContentGroup.NAME_FIELD
                + " varchar(255) NOT NULL, "
                + ContentGroup.ENABLED_FIELD
                + " bit NOT NULL, PRIMARY KEY ("
                + ContentGroup.ID_FIELD
                + "))");
    stmt.execute();
    // Create the users table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + User.TABLE
                + " ("
                + User.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + User.NAME_FIELD
                + " varchar(255) NOT NULL, PRIMARY KEY ("
                + User.ID_FIELD
                + "))");
    stmt.execute();
    // Create the achievements table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + Achievement.TABLE
                + " ("
                + Achievement.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + Achievement.NAME_FIELD
                + " varchar(255) NOT NULL, "
                + Achievement.REWARD_FIELD
                + " int NOT NULL, PRIMARY KEY ("
                + Event.ID_FIELD
                + "))");
    stmt.execute();
    // Create the table for the 'has achieved' relation
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + Achievement.ACHIEVED_TABLE
                + " ("
                + Achievement.ACHIEVED_USER_ID_FIELD
                + " bigint NOT NULL, "
                + Achievement.ACHIEVED_ACHIEVEMENT_ID_FIELD
                + " int NOT NULL, "
                + " FOREIGN KEY ("
                + Achievement.ACHIEVED_USER_ID_FIELD
                + ") REFERENCES "
                + User.TABLE
                + "("
                + User.ID_FIELD
                + "), "
                + " FOREIGN KEY ("
                + Achievement.ACHIEVED_ACHIEVEMENT_ID_FIELD
                + ") REFERENCES "
                + Achievement.TABLE
                + "("
                + Achievement.ID_FIELD
                + "))");
    stmt.execute();
    // Create the events table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + Event.TABLE
                + " ("
                + Event.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + Event.NAME_FIELD
                + " varchar(255) NOT NULL,"
                + Event.DESC_FIELD
                + " varchar(4096), "
                + Event.START_FIELD
                + " timestamp NOT NULL, "
                + Event.END_FIELD
                + " timestamp NOT NULL, PRIMARY KEY ("
                + Event.ID_FIELD
                + "))");
    stmt.execute();
    // Create the table for the 'is interested in' relation
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + Event.INTERESTED_TABLE
                + " ("
                + Event.INTERESTED_USER_ID_FIELD
                + " bigint NOT NULL, "
                + Event.INTERESTED_EVENT_ID_FIELD
                + " int NOT NULL, "
                + " FOREIGN KEY ("
                + Event.INTERESTED_USER_ID_FIELD
                + ") REFERENCES "
                + User.TABLE
                + "("
                + User.ID_FIELD
                + "), "
                + " FOREIGN KEY ("
                + Event.INTERESTED_EVENT_ID_FIELD
                + ") REFERENCES "
                + Event.TABLE
                + "("
                + Event.ID_FIELD
                + "))");
    stmt.execute();
    // Create the maps table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + ConferenceMap.TABLE
                + " ("
                + ConferenceMap.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + ConferenceMap.NAME_FIELD
                + " varchar(255) NOT NULL,"
                + ConferenceMap.IMAGE_FIELD
                + " varchar(4351) NOT NULL, PRIMARY KEY ("
                + ConferenceMap.ID_FIELD
                + "))");
    stmt.execute();
    // Create the markers table
    stmt =
        conc.prepareStatement(
            "CREATE TABLE "
                + MapMarker.TABLE
                + " ("
                + MapMarker.ID_FIELD
                + " bigint NOT NULL "
                + AUTOINC
                + ", "
                + MapMarker.MAP_FIELD
                + " bigint NOT NULL, "
                + MapMarker.NAME_FIELD
                + " varchar(255) NOT NULL,"
                + MapMarker.DESC_FIELD
                + " varchar(4096), "
                + MapMarker.X_FIELD
                + " int NOT NULL, "
                + MapMarker.Y_FIELD
                + " int NOT NULL, PRIMARY KEY ("
                + MapMarker.ID_FIELD
                + "), FOREIGN KEY ("
                + MapMarker.MAP_FIELD
                + ") REFERENCES "
                + ConferenceMap.TABLE
                + "("
                + ConferenceMap.ID_FIELD
                + ")"
                + ")");
    stmt.execute();
  }

  /** @return a connection to the test database */
  public static Connection getConnection() throws Exception {
    return databaseTester.getConnection().getConnection();
  }

  /** Cleans up the database test envinroment, ready for the next test. */
  public static void cleanup() throws Exception {
    databaseTester.onTearDown();
    databaseTester = null;
  }
}
