<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
  version="1.0" 
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library" 
  xmlns:af1="urn:atomicf1.extensions"
  xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" xmlns:tagsLib="urn:tagsLib" xmlns:BlogLibrary="urn:BlogLibrary" xmlns:atomicf1.extensions="urn:atomicf1.extensions" xmlns:ucomponents.cms="urn:ucomponents.cms" xmlns:ucomponents.random="urn:ucomponents.random" xmlns:ucomponents.request="urn:ucomponents.request" xmlns:ucomponents.urls="urn:ucomponents.urls" xmlns:uTube.XSLT="urn:uTube.XSLT" xmlns:PS.XSLTsearch="urn:PS.XSLTsearch" xmlns:UCommentLibrary="urn:UCommentLibrary" 
  exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets tagsLib BlogLibrary atomicf1.extensions ucomponents.cms ucomponents.random ucomponents.request ucomponents.urls uTube.XSLT PS.XSLTsearch UCommentLibrary ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
  <xsl:variable name="media" select="umbraco.library:GetMedia(number($currentPage/circuitImageAlt), 0)" />
  <div class="PodBorder">
    <div class="Pod">
      <div class="CircuitDetail Statistics">
          <table width="400px">
              <colgroup>
                  <th width="130px"></th>
                  <td></td>
              </colgroup>
              <tr>
                <td colspan="2"><img src="/ImageGen.ashx?image={$media/umbracoFile}&amp;width=400" alt="Circuit Map" /></td>                    
              </tr>                        
              <tr>
                  <th>Circuit</th>
                <td><xsl:value-of select="af1:GetCircuit($currentPage/circuitId)//circuit/name" /></td>
              </tr>                            
              <tr>
                  <th>Location</th>
                <td><xsl:value-of select="af1:GetCircuit($currentPage/circuitId)//circuit/location" />, <xsl:value-of select="af1:GetCircuit($currentPage/circuitId)//circuit/country" /></td>
              </tr>                            
          </table>
      </div>
    </div>
  </div>
</xsl:template>

</xsl:stylesheet>