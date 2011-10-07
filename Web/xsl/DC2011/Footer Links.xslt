<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:sc="http://www.sitecore.net/sc" 
  xmlns:dot="http://www.sitecore.net/dot"
  xmlns:dc2011="http://www.nextdigital.com/dc2011"
  exclude-result-prefixes="dot sc dc2011">

<xsl:import href="Common.xslt"/>

<!-- output directives -->
<xsl:output method="html" indent="no" encoding="UTF-8" />

<!-- parameters -->
<xsl:param name="lang" select="'en'"/>
<xsl:param name="id" select="''"/>
<xsl:param name="sc_item"/>
<xsl:param name="sc_currentitem"/>

<xsl:variable name="home" select="dc2011:GetHomeItem()"/>

<!-- entry point -->
<xsl:template match="*">
  <xsl:apply-templates select="$sc_item" mode="main"/>
</xsl:template>

<!--==============================================================-->
<!-- main                                                         -->
<!--==============================================================-->
<xsl:template match="*" mode="main">
  <nav class="footer">
    <ul>
      <xsl:for-each select="sc:Split('footer links', $home)">
        <xsl:variable name="item" select="sc:item(.,.)"/>
        <li>
          <sc:link select="$item">
            <xsl:apply-templates mode="menu-title" select="$item"/>
          </sc:link>
        </li>
      </xsl:for-each>
    </ul>
  </nav>
</xsl:template>

</xsl:stylesheet>