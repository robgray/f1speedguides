<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt" 
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:AtomicF1Statistics="urn:AtomicF1Statistics" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary AtomicF1Statistics uTube.XSLT UCommentLibrary ">

<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<!-- update this variable on how deep your site map should be -->
<xsl:variable name="maxLevelForSitemap" select="3"/>

<xsl:template match="/">

<xsl:call-template name="drawNodes">  
<xsl:with-param name="parent" select="$currentPage/ancestor-or-self::* [@isDoc and @level=1]"/>  
</xsl:call-template>

</xsl:template>

<xsl:template name="drawNodes">
<xsl:param name="parent"/> 
<xsl:if test="umbraco.library:IsProtected($parent/@id, $parent/@path) = 0 or (umbraco.library:IsProtected($parent/@id, $parent/@path) = 1 and umbraco.library:IsLoggedOn() = 1)">
<ul>
  <xsl:for-each select="$parent/* [@isDoc and string(umbracoNaviHide) != '1' and @level &lt;= $maxLevelForSitemap]"> 
<xsl:sort select="@sortOrder" data-type="number" />
  <li>  
<a href="{umbraco.library:NiceUrl(@id)}">
<xsl:value-of select="@nodeName"/></a>  
<xsl:if test="count(./* [@isDoc and string(umbracoNaviHide) != '1' and @level &lt;= $maxLevelForSitemap]) &gt; 0">   
<xsl:call-template name="drawNodes">    
<xsl:with-param name="parent" select="."/>    
</xsl:call-template>  
</xsl:if> 
</li>
</xsl:for-each>
</ul>
</xsl:if>
</xsl:template>
</xsl:stylesheet>