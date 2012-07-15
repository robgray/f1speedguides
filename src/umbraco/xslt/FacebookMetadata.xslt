<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary"
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary ">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:variable name="niceURL">
<xsl:value-of select="umbraco.library:NiceUrl($currentPage/@id)" />
</xsl:variable>

<xsl:variable name="title">
  <xsl:value-of select="$currentPage/@nodeName" />
</xsl:variable>

<xsl:template match="/">
 
<meta property="og:title" content="{$title}" />  
  <xsl:choose>
<xsl:when test="$currentPage/thumbnail &gt; 0">
  <xsl:variable name="mediaNode" select="umbraco.library:GetMedia($currentPage/thumbnail, 0)" />
  <meta property="og:image" content="http://www.atomicf1.com{$mediaNode/umbracoFile}" />  
</xsl:when>
<xsl:otherwise>
    <meta property="og:image" content="http://www.atomicf1.com/images/atomicf1-fb.png" />
</xsl:otherwise>
</xsl:choose>
  <meta property="og:url" content="http://www.atomicf1.com{$niceURL}" />
  <meta property="og:type" content="article" />
<meta property="og:site_name" content="www.atomicf1.com" />
  <meta property="fb:app_id" content="212256185471696" />
<meta property="fb:admins" content="664163054" />
    </xsl:template>

</xsl:stylesheet>