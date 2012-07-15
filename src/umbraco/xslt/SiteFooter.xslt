<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:atomicf1.extensions="urn:atomicf1.extensions" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary uTube.XSLT atomicf1.extensions PS.XSLTsearch UCommentLibrary ">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
  <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />
  
  <div class="list left">
    <h5><xsl:value-of select="$home/leftListTitle" /></h5>
    <ul>
      <xsl:for-each select="$home/leftList/links/link">
        <xsl:call-template name="listitem">
           <xsl:with-param name="item" select="."/>
        </xsl:call-template>        
      </xsl:for-each>
    </ul>
  </div>
  
  <div class="list center">
      <h5><xsl:value-of select="$home/centerListTitle" /></h5>
    <ul>
      <xsl:for-each select="$home/centerList/links/link">
        <xsl:call-template name="listitem">
           <xsl:with-param name="item" select="."/>
        </xsl:call-template>       
      </xsl:for-each>
    </ul>
  </div>
  
  <div class="list right">
      <h5><xsl:value-of select="$home/rightListTitle" /></h5>
    <ul>
      <xsl:for-each select="$home/rightList/links/link">
        <xsl:call-template name="listitem">
           <xsl:with-param name="item" select="."/>
        </xsl:call-template>       
      </xsl:for-each>
    </ul>
  </div>

</xsl:template>
    
<xsl:template name="listitem">
  <xsl:param name="post"/>
  
  <li>
    <xsl:element name="a">
    <xsl:if test="./@newwindow = '1'">
      <xsl:attribute name="target">_blank</xsl:attribute>
    </xsl:if>
    <xsl:choose>
      <xsl:when test="./@type = 'external'">
        <xsl:attribute name="href">
          <xsl:value-of select="./@link"/>
        </xsl:attribute>
      </xsl:when>
      <xsl:otherwise>
        <xsl:attribute name="href">
          <xsl:value-of select="umbraco.library:NiceUrl(./@link)"/>
        </xsl:attribute>
      </xsl:otherwise>
    </xsl:choose>
    <xsl:value-of select="./@title"/>
    </xsl:element>
  </li>
  
</xsl:template>  

</xsl:stylesheet>