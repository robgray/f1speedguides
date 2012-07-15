<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  exclude-result-prefixes="msxml umbraco.library">
    
<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>
<xsl:param name="showTeaser" select="/macro/showTeaser"/>
  

<xsl:template match="/">

  <xsl:variable name="items" select="$currentPage/Guide"/>
  
<!-- The fun starts here -->
    
<xsl:if test="count($items) &gt; 0">
<ul class="NewsList">
<xsl:for-each select="$items">  
  <xsl:sort select="@sortOrder" data-type="number" />
  <li>
    <div class="Item">      
      <xsl:if test="./thumbnail &gt; 0">
      <xsl:variable name="mediaNode" select="umbraco.library:GetMedia(./thumbnail, 0)" />
        <div class="fl" style="margin-right: 15px;">
        <a href="{umbraco.library:NiceUrl(@id)}">        
          <img src="/ImageGen.ashx?image={$mediaNode/umbracoFile}&amp;width=120" alt="{$mediaNode/altText}"  />
        </a>
        </div>
      </xsl:if>
      <div class="Text">
        <h3><a href="{umbraco.library:NiceUrl(@id)}">
          <xsl:value-of select="@nodeName"/>
          </a></h3>
        <xsl:if test="$showTeaser = 1">
          <div><xsl:value-of select="teaser"/></div>
        </xsl:if>
      </div>
          <div class="clear"></div>
    </div>
  </li>
</xsl:for-each>
</ul>
    </xsl:if>

</xsl:template>

</xsl:stylesheet>