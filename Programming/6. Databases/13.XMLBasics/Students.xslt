<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>School</h1>
        <table bgcolor="#E0E0E0" cellspacing="1" border="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birth Date</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
            <td>
              <b>Email</b>
            </td>
            <td>
              <b>Course</b>
            </td>
            <td>
              <b>Specialty</b>
            </td>
            <td>
              <b>Faculty Number</b>
            </td>
            <td>
              <b>
                Enrollments <br />Date: Score
              </b>
            </td>
            <td>
              <b>
                Exams <br />Tutor: Score
              </b>
            </td>
          </tr>
          <xsl:for-each select="/school/student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birth_date"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="faculty_number"/>
              </td>
              <td>
                <ul>
                <xsl:for-each select="enrollment">
                  <li>
                    <xsl:value-of select="date"/>
                  </li>
                  <li>
                    <xsl:value-of select="score"/>
                  </li>
                </xsl:for-each>
                </ul>
              </td>
              <td>
                <ul>
                  <xsl:for-each select="exams/exam">
                    <li>
                      <xsl:value-of select="exam_name"/>
                    </li>
                    <li>
                      <xsl:value-of select="tutor"/>
                    </li>
                    <li>
                      <xsl:value-of select="score"/>
                    </li>
                  </xsl:for-each>
                </ul>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>