<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:af1="urn:atomicf1.extensions"
  exclude-result-prefixes="msxml umbraco.library af1">
    
<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">

  <xsl:variable name="items" select="$currentPage/* [@isDoc and string(umbracoNaviHide) != '1']"/>
  
<!-- The fun starts here -->
    
<xsl:if test="count($items) &gt; 0">
<div class="TiledMenu">  
<ul>
<xsl:for-each select="$items">      
 

  <xsl:variable name="media" select="umbraco.library:GetMedia(number(circuitImageAlt), 0)" />
  <li class="Item">
    <div class="MenuTileOff">                    
      <a href="{umbraco.library:NiceUrl(@id)}" style="position: relative;">                         
        <strong><xsl:value-of select="af1:GetCircuit(circuitId)//circuit/country" /></strong>
        <img src="/ImageGen.ashx?image={$media/umbracoFile}&amp;width=90" alt="Circuit Map" style="position:absolute; left: 10px; bottom: 40px;"/>        
        <div style="position:absolute;bottom:5px;text-align: center;width:100%; margin-left: -15px;"><xsl:value-of select="@nodeName"/></div>                      
      </a>
    </div>
  </li>
</xsl:for-each>
</ul>
  </div>
    </xsl:if>

</xsl:template>

</xsl:stylesheet>