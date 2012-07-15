<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:atomicf1.extensions="urn:atomicf1.extensions" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary uTube.XSLT atomicf1.extensions PS.XSLTsearch UCommentLibrary ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
  <xsl:variable name="home" select="$currentPage/ancestor-or-self::Homepage" />

  <div class="VideoList">
  
<!-- start writing XSLT -->
  <xsl:for-each select="$home//Season">    
    <xsl:if test="count(.//Video) &gt;0 ">
      <h2><xsl:value-of select="./@nodeName" /></h2>
      <xsl:for-each select=".//Race">        
        <xsl:if test="count(.//Video) &gt; 0">          
          <h3><xsl:value-of select="./@nodeName" /></h3>
          <ul>
          <xsl:for-each select=".//Video">
            <xsl:sort select="@sortOrder" />
            <li>
              <a href="{umbraco.library:NiceUrl(@id)}">
                <xsl:value-of select="@nodeName"/>
              </a>
            </li>
          </xsl:for-each>          
          </ul>
        </xsl:if>
      </xsl:for-each>
    </xsl:if>    
  </xsl:for-each>
  
    <xsl:if test="count($home/Videos/Video) &gt; 0">
      <h2>Other</h2>
      <ul>      
      <xsl:for-each select="$home/Videos/Video">
          <xsl:sort select="@sortOrder" />
          <li>
            <a href="{umbraco.library:NiceUrl(@id)}">
              <xsl:value-of select="@nodeName"/>
            </a>
          </li>
      </xsl:for-each>
    </ul>
    </xsl:if>
    
  </div>
  
</xsl:template>

</xsl:stylesheet>