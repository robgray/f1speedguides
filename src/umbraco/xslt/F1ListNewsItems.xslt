<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
  <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
  version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxml="urn:schemas-microsoft-com:xslt"
  xmlns:umbraco.library="urn:umbraco.library"
  xmlns:tagsLib="urn:tagsLib"
  xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings"
  xmlns:BlogLibrary="urn:BlogLibrary"
  exclude-result-prefixes="msxml umbraco.library tagsLib Exslt.ExsltStrings BlogLibrary">


  <xsl:output method="html" omit-xml-declaration="yes"/>

  <xsl:param name="currentPage"/>
  
  <xsl:param name="numberOfPosts" select="/macro/numberOfPosts"/>
  <xsl:variable name="items" select="$currentPage//umbBlogPost"/>

  <xsl:template match="/">        
    <div class="LatestNews">      
      <xsl:if test="$numberOfPosts = 0">
        <h2>All News &amp; Reviews</h2>                     
      </xsl:if>
      <xsl:if test="$numberOfPosts &gt; 0">
        <h2>Latest News</h2>                     
      </xsl:if>
<!-- The fun starts here -->    
<xsl:if test="count($items) &gt; 0">
<ul class="NewsList">
<xsl:for-each select="$items">    
<xsl:sort select="./PostDate" order="descending" />
  <xsl:if test="position() &lt;= $numberOfPosts or $numberOfPosts = 0">
  <li>
    <div class="Item">      
      <xsl:choose>
        <xsl:when test="./thumbnail &gt; 0">
          <xsl:variable name="mediaNode" select="umbraco.library:GetMedia(./thumbnail, 0)" />       
          <div class="fl" style="margin-right: 15px;">
          <a href="{umbraco.library:NiceUrl(@id)}">        
            <img src="/ImageGen.ashx?image={$mediaNode/umbracoFile}&amp;width=120" alt="{$mediaNode/altText}"  />
          </a>
          </div>
        </xsl:when>
        <xsl:otherwise>
          <xsl:variable name="mediaNode" select="umbraco.library:GetMedia(1688, 0)" />       
          <div class="fl" style="margin-right: 15px;">
          <a href="{umbraco.library:NiceUrl(@id)}">        
            <img src="/ImageGen.ashx?image={$mediaNode/umbracoFile}&amp;width=120" alt="{$mediaNode/altText}"  />
          </a>
          </div>
        </xsl:otherwise>
      </xsl:choose>      
          
      <div class="Text">
        <xsl:variable name="tags" select="tagsLib:getTagsFromNode(@id)" />     
        <h3>
          <a href="{umbraco.library:NiceUrl(@id)}">
            <xsl:if test="count($tags) &gt; 0">
              <xsl:for-each select="$tags">
                <xsl:if test=". = 'Real World'">
                  [Real-World]
                </xsl:if>
                <xsl:if test=". = 'Review'">
                  [Review]
                </xsl:if>
              </xsl:for-each>
            </xsl:if>
          <xsl:value-of select="@nodeName"/>
          </a>
        </h3>
         <div class="entry-date">
          <abbr class="published" title="{umbraco.library:ShortDate(./PostDate)}">
             <span class="day"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'dd')"/></span>
             <span class="month"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'MMM')"/></span>
             <span class="year"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'yyyy')"/></span>
            <span class="time"><xsl:value-of select="umbraco.library:FormatDateTime(./PostDate, 'HH:mm')"/></span>
          </abbr>
        </div>      

        <div class="Teaser"><xsl:value-of select="teaser"/></div>
      </div>
      <div class="clear"></div>
    </div>
  </li>
  </xsl:if>
</xsl:for-each>
  <xsl:if test="position() &lt;= number($numberOfPosts) and number($numberOfPosts) &gt; 0">
    <li class="MoreLink"><a href="/news">View all News &gt;</a></li>
  </xsl:if>
  </ul>
    </xsl:if>
    </div>
  </xsl:template>
</xsl:stylesheet>