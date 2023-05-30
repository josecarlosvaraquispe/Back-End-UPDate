using Domain;
using Infraestructure;
using Infraestructure.DataClass;

namespace UpDate.Domain.Test;
using Moq;

public class CommunityUnitTest
{
    [Fact]
    public void Create_ValidCommunity_ReturnSuccess()
    {
        CommunityData communityData = new CommunityData()
        {
            Name = "Community Test",
            Description = "This is a test description"
        };
        
        var mockCommunityInfraestructure = new Mock<ICommunityInfraestructure>();
        mockCommunityInfraestructure.Setup(t =>
                t.Create(communityData))
            .Returns(true);
        CommunityDomain communityDomain = new CommunityDomain(mockCommunityInfraestructure.Object);

        var returnValue = communityDomain.Create(communityData);
        
        Assert.True(returnValue);
    }

    [Fact]
    public void Create_InvalidCommunity_ReturnError()
    {
        CommunityData communityData = new CommunityData()
        {
            Name = "Community Test",
            Description = "This is a test description"
        };
        
        var mockCommunityInfraestructure = new Mock<ICommunityInfraestructure>();
        mockCommunityInfraestructure.Setup(t =>
                t.Create(communityData))
            .Returns(false);
        CommunityDomain communityDomain = new CommunityDomain(mockCommunityInfraestructure.Object);

        var returnValue = communityDomain.Create(communityData);
        
        Assert.False(returnValue);
    }
}