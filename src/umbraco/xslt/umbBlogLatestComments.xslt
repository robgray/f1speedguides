<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
  <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:UCommentLibrary="urn:UCommentLibrary"
  exclude-result-prefixes="msxml umbraco.library UCommentLibrary">


  <xsl:output method="html" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>
  <xsl:variable name="numberOfComments" select="6"/>
  <xsl:variable name="comments" select="UCommentLibrary:GetComments()//comment" />
 
  <xsl:template match="/">
  
    <xsl:if test="count($comments) &gt; 0">
     <div class="StandingsTable Pod">
      <h2>Latest Comments</h2>
    <ul class="LatestComments">
   <xsl:for-each select="$comments">
        <xsl:sort select="umbraco.library:FormatDateTime(@created, 'yyyy-MM-dd HH:mm:ss')" order="descending" />
        <xsl:if test="position() &lt; $numberOfComments + 1">
          <li class="comment-item">
            <a href="{umbraco.library:NiceUrl(@nodeid)}#comment-{@id}">              
              <strong><xsl:value-of select="./name"/></strong> on <xsl:value-of select="umbraco.library:GetXmlNodeById(@nodeid)/@nodeName"/>
            </a>
          </li>
        </xsl:if>
      </xsl:for-each>
    </ul>
      </div>
</xsl:if>

  </xsl:template>

</xsl:stylesheet>