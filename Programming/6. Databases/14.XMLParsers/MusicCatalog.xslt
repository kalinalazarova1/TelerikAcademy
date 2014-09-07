<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Music Catalogue</h1>
        <table bgcolor="#E0E0E0" cellspacing="1" cellpadding="1" border="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Album</b>
            </td>
            <td>
              <b>Artist</b>
            </td>
            <td>
              <b>Year</b>
            </td>
            <td>
              <b>Producer</b>
            </td>
            <td>
              <b>Price</b>
            </td>
            <td>
              <b>
                Songs<br/>
                Title : Duration
              </b>
            </td>
          </tr>
          <xsl:for-each select="catalogue/album">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
              <td>
                <ul>
                  <xsl:for-each select="songs/song">
                    <li>
                      <xsl:value-of select="title"/> :
                      <xsl:value-of select="duration"/>
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