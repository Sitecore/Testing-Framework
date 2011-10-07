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
  <xsl:variable name="wrap-required" select="substring(sc:fld('text',.),0,3) = '&lt;p&gt;'"/>
  <h1>
    <xsl:apply-templates mode="title" select="."/>
  </h1>
  <div class="page-content">
    <sc:image field="thumbnail" mw="200" mh="150"/>
    <xsl:if test="$wrap-required">
      <xsl:text disable-output-escaping="yes">&lt;p&gt;</xsl:text>
    </xsl:if>
    <sc:html field="text"/>
    <xsl:if test="$wrap-required">
      <xsl:text disable-output-escaping="yes">&lt;/p&gt;</xsl:text>
    </xsl:if>
  </div>
</xsl:template>
  
</xsl:stylesheet>