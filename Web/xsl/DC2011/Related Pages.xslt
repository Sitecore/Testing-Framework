<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:sc="http://www.sitecore.net/sc" 
  xmlns:dot="http://www.sitecore.net/dot"
  exclude-result-prefixes="dot sc">

<xsl:import href="Common.xslt"/>

<!-- output directives -->
<xsl:output method="html" indent="no" encoding="UTF-8" />

<!-- parameters -->
<xsl:param name="lang" select="'en'"/>
<xsl:param name="id" select="''"/>
<xsl:param name="sc_item"/>
<xsl:param name="sc_currentitem"/>

<!-- entry point -->
<xsl:template match="*">
  <xsl:apply-templates select="$sc_item" mode="main"/>
</xsl:template>

<!--==============================================================-->
<!-- main                                                         -->
<!--==============================================================-->
<xsl:template match="*" mode="main">
  <div class="related-pages">
    <xsl:if test="sc:fld('related pages',.) != ''">
      <h3>Related Pages</h3>
      <ul class="related">
        <xsl:for-each select="sc:Split('related pages',.)">
          <xsl:variable name="item" select="sc:item(.,.)"/>
          <li>
            <sc:link select="$item">
              <xsl:apply-templates mode="menu-title" select="$item"/>
            </sc:link>
          </li>
        </xsl:for-each>
      </ul>
    </xsl:if>
  </div>
</xsl:template>

</xsl:stylesheet>