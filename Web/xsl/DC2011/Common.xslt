<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:sc="http://www.sitecore.net/sc"
  xmlns:dot="http://www.sitecore.net/dot"
  xmlns:dc2011="http://www.nextdigital.com/dc2011"
  exclude-result-prefixes="dot sc dc2011">

  <xsl:template match="*" mode="title">
    <xsl:choose>
      <xsl:when test="sc:fld('title',.) != ''">
        <sc:text field="title"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="@name"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  
  <xsl:template match="*" mode="menu-title">
    <xsl:choose>
      <xsl:when test="sc:fld('menu title',.) != ''">
        <sc:text field="menu title"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:apply-templates mode="title" select="."/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>