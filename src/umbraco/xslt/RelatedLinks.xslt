<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" 
  xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" 
  xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" 
  xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" 
  xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" 
  xmlns:atomicf1.extensions="urn:atomicf1.extensions"  
  xmlns:ucomponents.cms="urn:ucomponents.cms" 
  xmlns:ucomponents.random="urn:ucomponents.random" xmlns:ucomponents.request="urn:ucomponents.request" 
  xmlns:ucomponents.urls="urn:ucomponents.urls" xmlns:uTube.XSLT="urn:uTube.XSLT" 
  xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary atomicf1.extensions ucomponents.cms ucomponents.random ucomponents.request ucomponents.urls uTube.XSLT PS.XSLTsearch UCommentLibrary ">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">  
  <xsl:if test="count($currentPage/relatedLinks/links/link) &gt; 0" >
  
  <div class="relatedlinks">
    <h2>Related Items</h2>
    <hr/>    
    <ul class="bullets">
      <xsl:for-each select="$currentPage/relatedLinks/links/link">
        <xsl:call-template name="listitem">           
           <xsl:with-param name="item" select="."/>
        </xsl:call-template>       
      </xsl:for-each>
    </ul>
  </div>    
  </xsl:if>
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